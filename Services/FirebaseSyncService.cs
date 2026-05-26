using ELGlamPOS.Data;
using ELGlamPOS.Models;
using ELGlamPOS.Models.Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ELGlamPOS.Services
{
    /// <summary>
    /// Handles all Firebase Realtime Database sync operations.
    ///
    /// Flow:
    ///   Booking System → /appointments (Firebase) → POS pulls → creates DraftOrders
    ///   POS completes → Transaction saved locally → pushed to /transactions (Firebase)
    ///   Analytics reads /transactions and /pos_daily_reports
    ///
    /// Strategy: SQLite-first. All writes go to SQLite immediately.
    /// Firebase sync happens in the background when online.
    /// Last-write-wins on conflicts.
    /// </summary>
    public class FirebaseSyncService : IFirebaseSyncService, IDisposable
    {
        private readonly IDbContextFactory<PosDbContext> _dbFactory;
        private readonly FirebaseConfigOptions _config;
        private readonly ILogger<FirebaseSyncService> _logger;
        private readonly IConnectivity _connectivity;

        private FirebaseClient? _client;
        private string? _idToken;
        private DateTime _tokenExpiry = DateTime.MinValue;
        private bool _isOnline;
        private readonly SemaphoreSlim _syncLock = new(1, 1);

        public bool IsOnline => _isOnline;
        public event Action<bool>? OnConnectivityChanged;

        public FirebaseSyncService(
            IDbContextFactory<PosDbContext> dbFactory,
            FirebaseConfigOptions config,
            ILogger<FirebaseSyncService> logger,
            IConnectivity connectivity)
        {
            _dbFactory = dbFactory;
            _config = config;
            _logger = logger;
            _connectivity = connectivity;
        }

        public void StartMonitoring()
        {
            _connectivity.ConnectivityChanged += OnConnectivityChangedHandler;
            // Check initial state
            _ = Task.Run(async () =>
            {
                var hasNet = _connectivity.NetworkAccess == NetworkAccess.Internet;
                await HandleConnectivityChange(hasNet);
            });
        }

        private async void OnConnectivityChangedHandler(object? sender, ConnectivityChangedEventArgs e)
        {
            var hasNet = e.NetworkAccess == NetworkAccess.Internet;
            await HandleConnectivityChange(hasNet);
        }

        private async Task HandleConnectivityChange(bool isConnected)
        {
            _isOnline = isConnected;
            OnConnectivityChanged?.Invoke(isConnected);

            if (isConnected && _config.IsConfigured)
            {
                _logger.LogInformation("[Sync] Network restored — starting sync cycle");
                await SyncAllAsync();
            }
        }

        // ─── Authentication ────────────────────────────────────────────────────────

        private async Task<FirebaseClient?> GetClientAsync()
        {
            if (!_config.IsConfigured)
            {
                _logger.LogWarning("[Sync] Firebase not configured — skipping sync");
                return null;
            }

            // Refresh token if expired (Firebase ID tokens last 1 hour)
            if (_client == null || DateTime.UtcNow >= _tokenExpiry)
            {
                try
                {
                    _idToken = await GetFirebaseIdTokenAsync();
                    _tokenExpiry = DateTime.UtcNow.AddMinutes(55); // 5 min buffer before 1hr expiry
                    _client = new FirebaseClient(
                        _config.DatabaseUrl,
                        new FirebaseOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(_idToken)
                        });
                    _logger.LogInformation("[Sync] Firebase client authenticated");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "[Sync] Firebase authentication failed");
                    _client = null;
                    return null;
                }
            }

            return _client;
        }

        private async Task<string> GetFirebaseIdTokenAsync()
        {
            using var http = new HttpClient();
            var url = $"https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key={_config.ApiKey}";
            var payload = JsonSerializer.Serialize(new
            {
                email = _config.PosEmail,
                password = _config.PosPassword,
                returnSecureToken = true
            });

            var response = await http.PostAsync(url,
                new StringContent(payload, System.Text.Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("idToken").GetString()
                ?? throw new Exception("No idToken in Firebase auth response");
        }

        // ─── Public Sync Methods ───────────────────────────────────────────────────

        public async Task SyncAllAsync(CancellationToken ct = default)
        {
            if (!await _syncLock.WaitAsync(0, ct)) return; // Skip if sync already running
            try
            {
                await PushMasterDataAsync(ct);
                await PullAppointmentsAsync(ct);
                await PushPendingTransactionsAsync(ct);
                await PushPendingDailyReportsAsync(ct);
            }
            finally
            {
                _syncLock.Release();
            }
        }

        // ─── Push Master Data → Firebase ──────────────────────────────────────────

        public async Task PushMasterDataAsync(CancellationToken ct = default)
        {
            var client = await GetClientAsync();
            if (client == null) return;

            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync(ct);
                _logger.LogInformation("[Sync] Pushing master data to Firebase...");

                var data = new
                {
                    branches = await db.Branches.AsNoTracking().ToListAsync(ct),
                    commission_rules = await db.CommissionRules.AsNoTracking().ToListAsync(ct),
                    employees = await db.Employees.AsNoTracking().ToListAsync(ct),
                    service_categories = await db.ServiceCategories.AsNoTracking().ToListAsync(ct),
                    service_items = await db.ServiceItems.AsNoTracking().ToListAsync(ct),
                    users = await db.Users.AsNoTracking().Select(u => new
                    {
                        u.Id,
                        u.UserName,
                        u.Email,
                        u.EmployeeId
                    }).ToListAsync(ct)
                };

                await client.Child("masterdata").PutAsync(data);
                _logger.LogInformation("[Sync] Master data pushed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Sync] Failed to push master data to Firebase.");
            }
        }

        // ─── Pull Appointments → DraftOrders ──────────────────────────────────────

        public async Task PullAppointmentsAsync(CancellationToken ct = default)
        {
            var client = await GetClientAsync();
            if (client == null) return;

            try
            {
                _logger.LogInformation("[Sync] Pulling appointments from Firebase...");

                var appointments = await client
                    .Child("appointments")
                    .OnceAsync<FirebaseAppointment>();

                await using var db = await _dbFactory.CreateDbContextAsync(ct);

                // Get existing DraftOrders keyed by their source Firebase appointment key
                var existingKeys = (await db.DraftOrders
                    .Where(d => d.SourceAppointmentKey != null)
                    .Select(d => d.SourceAppointmentKey!)
                    .ToListAsync(ct)).ToHashSet();

                // Load employees with their Firebase name keys for matching
                var employees = await db.Employees
                    .Where(e => e.IsActive)
                    .ToListAsync(ct);

                int imported = 0;
                foreach (var apptObj in appointments)
                {
                    ct.ThrowIfCancellationRequested();

                    var key = apptObj.Key;
                    var appt = apptObj.Object;

                    // Only import pending appointments we haven't seen yet
                    if (appt.Status != "pending" || existingKeys.Contains(key))
                        continue;

                    // Map Firebase branchId string → local Branch.Id
                    if (!FirebaseAppointment.BranchIdMap.TryGetValue(appt.BranchId, out int localBranchId))
                    {
                        _logger.LogWarning("[Sync] Unknown branchId '{BranchId}' in appointment {Key}", appt.BranchId, key);
                        continue;
                    }

                    // Find or pick a default receptionist for this branch
                    var receptionist = employees.FirstOrDefault(e =>
                        e.BranchId == localBranchId && e.Role == EmployeeRole.Receptionist && e.IsActive)
                        ?? employees.FirstOrDefault(e => e.BranchId == localBranchId && e.IsActive);

                    if (receptionist == null)
                    {
                        _logger.LogWarning("[Sync] No active employee found for branch {BranchId}, skipping appointment {Key}", localBranchId, key);
                        continue;
                    }

                    var draft = new DraftOrder
                    {
                        CreatedDate = appt.GetCreatedAtUtc(),
                        AppointmentDate = appt.GetPreferredDateTime(),
                        Status = DraftOrderStatus.Draft,
                        CustomerName = appt.CustomerName,
                        CustomerContactNo = appt.Phone,
                        Note = appt.Notes,
                        BranchId = localBranchId,
                        CreatedByEmployeeId = receptionist.Id,
                        SourceAppointmentKey = key,
                        Items = new List<DraftOrderItem>()
                    };

                    // Map each service in the appointment to a DraftOrderItem
                    foreach (var svc in appt.Services)
                    {
                        // Find matching ServiceItem by name (case-insensitive)
                        var serviceItem = await db.ServiceItems
                            .FirstOrDefaultAsync(s => s.IsActive &&
                                s.Name.ToLower() == svc.Name.ToLower(), ct);

                        if (serviceItem == null)
                        {
                            _logger.LogWarning("[Sync] Service '{ServiceName}' not found locally, skipping item", svc.Name);
                            continue;
                        }

                        // Match assigned stylist to local employee
                        var assignedStylist = svc.AssignedStylists.FirstOrDefault();
                        Employee? assignedEmployee = null;
                        if (assignedStylist != null)
                        {
                            // Firebase name format: "LastName, FirstName" — try FirebaseNameKey first, then robust fuzzy match
                            assignedEmployee = employees.FirstOrDefault(e =>
                                e.BranchId == localBranchId &&
                                ((!string.IsNullOrEmpty(e.FirebaseNameKey) && e.FirebaseNameKey == assignedStylist.Name) ||
                                 IsNameMatch(e.Name, assignedStylist.Name)));
                        }

                        draft.Items.Add(new DraftOrderItem
                        {
                            ServiceItemId = serviceItem.Id,
                            AssignedEmployeeId = assignedEmployee?.Id,
                            FinalPrice = svc.Price
                        });
                    }

                    db.DraftOrders.Add(draft);
                    imported++;
                }

                if (imported > 0)
                {
                    await db.SaveChangesAsync(ct);
                    _logger.LogInformation("[Sync] Imported {Count} new appointments as draft orders", imported);
                }
                else
                {
                    _logger.LogInformation("[Sync] No new appointments to import");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Sync] Failed to pull appointments from Firebase");
            }
        }

        // ─── Push Transactions → Firebase ─────────────────────────────────────────

        public async Task PushPendingTransactionsAsync(CancellationToken ct = default)
        {
            var client = await GetClientAsync();
            if (client == null) return;

            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync(ct);

                var pending = await db.Transactions
                    .Include(t => t.Branch)
                    .Include(t => t.Receptionist)
                    .Include(t => t.Items)
                        .ThenInclude(i => i.ServiceItem)
                            .ThenInclude(s => s.Category)
                    .Include(t => t.Items)
                        .ThenInclude(i => i.AssignedEmployee)
                    .Where(t => t.SyncStatus == SyncStatus.Pending)
                    .ToListAsync(ct);

                _logger.LogInformation("[Sync] Pushing {Count} pending transactions...", pending.Count);

                foreach (var tx in pending)
                {
                    ct.ThrowIfCancellationRequested();
                    try
                    {
                        var dto = FirebaseTransaction.FromTransaction(tx, tx.Branch?.Name ?? string.Empty);

                        // Use PUT with the local ID as key for idempotency (re-push same transaction = same key)
                        await client
                            .Child("transactions")
                            .Child($"pos-{tx.Id}")
                            .PutAsync(dto);

                        // If this was from an appointment, mark it completed in Firebase
                        if (!string.IsNullOrEmpty(tx.SourceAppointmentKey))
                        {
                            await UpdateAppointmentStatusAsync(tx.SourceAppointmentKey, "completed", ct);
                        }

                        tx.SyncStatus = SyncStatus.Synced;
                        tx.FirebaseKey = $"pos-{tx.Id}";
                        tx.LastSyncedAt = DateTime.UtcNow;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "[Sync] Failed to push transaction {Id}", tx.Id);
                        tx.SyncStatus = SyncStatus.Failed;
                    }
                }

                await db.SaveChangesAsync(ct);

                // Retry failed ones (they'll be picked up next sync cycle automatically)
                var failedCount = pending.Count(t => t.SyncStatus == SyncStatus.Failed);
                if (failedCount > 0)
                    _logger.LogWarning("[Sync] {Count} transactions failed to sync — will retry on next cycle", failedCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Sync] Failed to push pending transactions");
            }
        }

        // ─── Push DailyReports → Firebase ─────────────────────────────────────────

        public async Task PushPendingDailyReportsAsync(CancellationToken ct = default)
        {
            var client = await GetClientAsync();
            if (client == null) return;

            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync(ct);

                var pending = await db.DailyReports
                    .Include(r => r.Branch)
                    .Where(r => r.SyncStatus == SyncStatus.Pending && r.SubmittedAt != null)
                    .ToListAsync(ct);

                _logger.LogInformation("[Sync] Pushing {Count} pending daily reports...", pending.Count);

                foreach (var report in pending)
                {
                    ct.ThrowIfCancellationRequested();
                    try
                    {
                        var dto = FirebaseDailyReport.FromDailyReport(report, report.Branch?.Name ?? string.Empty);

                        await client
                            .Child("pos_daily_reports")
                            .Child($"report-{report.Id}")
                            .PutAsync(dto);

                        report.SyncStatus = SyncStatus.Synced;
                        report.FirebaseKey = $"report-{report.Id}";
                        report.LastSyncedAt = DateTime.UtcNow;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "[Sync] Failed to push daily report {Id}", report.Id);
                        report.SyncStatus = SyncStatus.Failed;
                    }
                }

                await db.SaveChangesAsync(ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Sync] Failed to push pending daily reports");
            }
        }

        // ─── Update Appointment Status ─────────────────────────────────────────────

        public async Task UpdateAppointmentStatusAsync(string firebaseKey, string status, CancellationToken ct = default)
        {
            var client = await GetClientAsync();
            if (client == null) return;

            try
            {
                await client
                    .Child("appointments")
                    .Child(firebaseKey)
                    .Child("status")
                    .PutAsync(status);

                _logger.LogInformation("[Sync] Updated appointment {Key} status → {Status}", firebaseKey, status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Sync] Failed to update appointment status for {Key}", firebaseKey);
            }
        }

        // ─── POS Account Sync ──────────────────────────────────────────────────────

        /// <summary>
        /// Encodes an email to a safe Firebase key (replaces . with , and @ with _at_).
        /// </summary>
        private static string EmailToKey(string email) =>
            email.Replace(".", ",").Replace("@", "_at_");

        /// <summary>
        /// Pushes this account's metadata to Firebase /pos_accounts so other devices can pull it.
        /// The PasswordToken should be set by the caller before invoking this.
        /// </summary>
        public async Task PushAccountAsync(string email, int employeeId, CancellationToken ct = default)
        {
            var client = await GetClientAsync();
            if (client == null) return;

            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync(ct);
                var employee = await db.Employees
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == employeeId, ct);

                if (employee == null)
                {
                    _logger.LogWarning("[Sync] PushAccountAsync: employee {Id} not found", employeeId);
                    return;
                }

                // Retrieve current password token if already stored (we never overwrite blindly)
                var key = EmailToKey(email);
                FirebasePosAccount? existing = null;
                try
                {
                    existing = await client.Child("pos_accounts").Child(key).OnceSingleAsync<FirebasePosAccount>();
                }
                catch { }

                var account = new FirebasePosAccount
                {
                    Email = email,
                    Name = employee.Name,
                    EmployeeId = employeeId,
                    BranchId = employee.BranchId,
                    Role = employee.Role.ToString(),
                    PasswordToken = existing?.PasswordToken, // preserve existing token unless caller updates it
                    UpdatedAt = DateTime.UtcNow.ToString("o")
                };

                await client.Child("pos_accounts").Child(key).PutAsync(account);
                _logger.LogInformation("[Sync] Pushed account {Email} to Firebase", email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Sync] Failed to push account {Email}", email);
            }
        }

        /// <summary>
        /// Pushes account to Firebase with a specific password token (used when creating or resetting passwords).
        /// </summary>
        public async Task PushAccountWithPasswordAsync(string email, int employeeId, string passwordToken, CancellationToken ct = default)
        {
            var client = await GetClientAsync();
            if (client == null) return;

            try
            {
                await using var db = await _dbFactory.CreateDbContextAsync(ct);
                var employee = await db.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == employeeId, ct);
                if (employee == null) return;

                var key = EmailToKey(email);
                var account = new FirebasePosAccount
                {
                    Email = email,
                    Name = employee.Name,
                    EmployeeId = employeeId,
                    BranchId = employee.BranchId,
                    Role = employee.Role.ToString(),
                    PasswordToken = passwordToken,
                    UpdatedAt = DateTime.UtcNow.ToString("o")
                };

                await client.Child("pos_accounts").Child(key).PutAsync(account);
                _logger.LogInformation("[Sync] Pushed account {Email} with password token to Firebase", email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Sync] Failed to push account with password {Email}", email);
            }
        }

        /// <summary>
        /// Pulls all /pos_accounts records from Firebase.
        /// Returns the list; the caller (SettingsPage) handles local Identity creation.
        /// </summary>
        public async Task<List<FirebasePosAccount>> PullAccountsAsync(CancellationToken ct = default)
        {
            var client = await GetClientAsync();
            if (client == null) return new List<FirebasePosAccount>();

            try
            {
                var records = await client.Child("pos_accounts").OnceAsync<FirebasePosAccount>();
                var result = records
                    .Where(r => r.Object != null)
                    .Select(r =>
                    {
                        r.Object.Email = r.Key.Replace(",", ".").Replace("_at_", "@");
                        return r.Object;
                    })
                    .ToList();

                _logger.LogInformation("[Sync] Pulled {Count} pos_accounts from Firebase", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Sync] Failed to pull pos_accounts");
                return new List<FirebasePosAccount>();
            }
        }

        public void Dispose()
        {
            _connectivity.ConnectivityChanged -= OnConnectivityChangedHandler;
            _syncLock.Dispose();
            _client?.Dispose();
        }
        private static bool IsNameMatch(string localName, string firebaseName)
        {
            if (string.Equals(localName, firebaseName, StringComparison.OrdinalIgnoreCase)) return true;
            
            var fbParts = firebaseName.Split(',', StringSplitOptions.TrimEntries);
            if (fbParts.Length == 2)
            {
                var reversed = $"{fbParts[1]} {fbParts[0]}"; // "FirstName LastName"
                if (string.Equals(localName, reversed, StringComparison.OrdinalIgnoreCase)) return true;
                
                var localNoSpace = localName.Replace(" ", "");
                var reversedNoSpace = reversed.Replace(" ", "");
                var forwardNoSpace = firebaseName.Replace(",", "").Replace(" ", "");
                
                if (string.Equals(localNoSpace, reversedNoSpace, StringComparison.OrdinalIgnoreCase)) return true;
                if (string.Equals(localNoSpace, forwardNoSpace, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }
    }
}
