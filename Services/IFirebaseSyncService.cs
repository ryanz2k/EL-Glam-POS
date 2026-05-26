using ELGlamPOS.Models;
using ELGlamPOS.Models.Firebase;

namespace ELGlamPOS.Services
{
    public interface IFirebaseSyncService
    {
        /// <summary>True when network is available and Firebase is authenticated.</summary>
        bool IsOnline { get; }

        /// <summary>Fires whenever connectivity state changes.</summary>
        event Action<bool> OnConnectivityChanged;

        /// <summary>
        /// Pull new/updated appointments from Firebase and upsert them as DraftOrders locally.
        /// </summary>
        Task PullAppointmentsAsync(CancellationToken ct = default);

        /// <summary>
        /// Push all SyncStatus.Pending transactions to Firebase /transactions.
        /// </summary>
        Task PushPendingTransactionsAsync(CancellationToken ct = default);

        /// <summary>
        /// Push all SyncStatus.Pending daily reports to Firebase /pos_daily_reports.
        /// </summary>
        Task PushPendingDailyReportsAsync(CancellationToken ct = default);

        /// <summary>
        /// Push all master data (Employees, Services, Branches, etc.) to Firebase /masterdata.
        /// </summary>
        Task PushMasterDataAsync(CancellationToken ct = default);

        /// <summary>
        /// Update an appointment's status in Firebase (e.g. "pending" → "completed").
        /// </summary>
        Task UpdateAppointmentStatusAsync(string firebaseKey, string status, CancellationToken ct = default);

        /// <summary>
        /// Runs a full sync cycle: pull appointments, push pending transactions and reports.
        /// Safe to call on every connectivity restore.
        /// </summary>
        Task SyncAllAsync(CancellationToken ct = default);

        /// <summary>Start listening to connectivity events. Call once at app startup.</summary>
        void StartMonitoring();

        /// <summary>Push a POS account record (email + hashed password metadata) to Firebase /pos_accounts.</summary>
        Task PushAccountAsync(string email, int employeeId, CancellationToken ct = default);

        /// <summary>Pull /pos_accounts from Firebase and create missing local Identity users with a reset-token flow.</summary>
        Task<List<FirebasePosAccount>> PullAccountsAsync(CancellationToken ct = default);
    }
}
