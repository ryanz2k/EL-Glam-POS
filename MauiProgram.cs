using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ELGlamPOS.Data;
using ELGlamPOS.Services;
using Microsoft.Extensions.Configuration;

using Microsoft.Maui.LifecycleEvents;
#if WINDOWS
using Microsoft.UI.Windowing;
using Microsoft.UI;
#endif

namespace ELGlamPOS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			})
			.ConfigureLifecycleEvents(events =>
			{
#if WINDOWS
				events.AddWindows(windows => windows
					.OnWindowCreated(window =>
					{
						var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
						var id = Win32Interop.GetWindowIdFromWindow(handle);
						var appWindow = AppWindow.GetFromWindowId(id);

						appWindow.Closing += (s, e) =>
						{
							e.Cancel = true;
							Application.Current?.Dispatcher.Dispatch(async () =>
							{
								if (Application.Current?.MainPage != null)
								{
									bool result = await Application.Current.MainPage.DisplayAlert(
										"Exit Application",
										"Are you sure you want to close the POS system?",
										"Yes", "No");

									if (result)
									{
										Application.Current.Quit();
									}
								}
							});
						};
					}));
#endif
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		// ── Load appsettings.json ──────────────────────────────────────────────────
		var configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
		if (File.Exists(configPath))
		{
			builder.Configuration.AddJsonFile(configPath, optional: true, reloadOnChange: false);
		}

		// ── Firebase Config ────────────────────────────────────────────────────────
		var firebaseConfig = new FirebaseConfigOptions();
		builder.Configuration.GetSection(FirebaseConfigOptions.SectionName).Bind(firebaseConfig);
		builder.Services.AddSingleton(firebaseConfig);

		// ── SQLite (local, offline-capable) ───────────────────────────────────────
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "pos_v3.db");
		builder.Services.AddDbContextFactory<PosDbContext>(options =>
			options.UseSqlite($"Filename={dbPath}"));
		builder.Services.AddDbContext<PosDbContext>(options =>
			options.UseSqlite($"Filename={dbPath}"));

		// ── Receipt Printers ──────────────────────────────────────────────────────
#if WINDOWS
		builder.Services.AddSingleton<IReceiptPrinterService, BluetoothReceiptPrinterService>();
#else
		builder.Services.AddSingleton<IReceiptPrinterService, MockReceiptPrinterService>();
#endif
		builder.Services.AddSingleton<ICommissionCalculatorService, CommissionCalculatorService>();

		// ── Identity ──────────────────────────────────────────────────────────────
		builder.Services.AddIdentityCore<Models.ApplicationUser>(options =>
		{
			options.Password.RequireDigit = false;
			options.Password.RequireLowercase = false;
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireUppercase = false;
			options.Password.RequiredLength = 6;
		})
		.AddEntityFrameworkStores<PosDbContext>();

		// ── App State & Auth ──────────────────────────────────────────────────────
		builder.Services.AddScoped<PosSessionState>();
		builder.Services.AddScoped<CartStateService>();
		builder.Services.AddScoped<Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider,
			LocalAuthenticationStateProvider>();
		builder.Services.AddAuthorizationCore();

		// ── Firebase Sync Service ─────────────────────────────────────────────────
		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<FirebaseConfigOptions>(sp => firebaseConfig);
		builder.Services.AddSingleton<IFirebaseSyncService, FirebaseSyncService>();

		var app = builder.Build();

		// ── Database Migration (replaces EnsureCreated + manual ALTER TABLE hacks) ─
		using (var scope = app.Services.CreateScope())
		{
			var context = scope.ServiceProvider.GetRequiredService<PosDbContext>();
			var logger = scope.ServiceProvider.GetService<ILogger<App>>();
			try
			{
				context.Database.Migrate();
				
				// Data migration for Service Area
				var salonCategories = new[] { "Hair Care", "Nail Care" };
				var clinicCategories = new[] { "Facial Care", "Warts Removal", "Eyelash Care", "Gluta Push and Drip", "Eyebrows Care", "hair and make up", "Body Care", "Facial & Body Slimming", "Message", "Waxing/Threading", "Permanent Hair Removal" };
				
				var servicesToUpdate = context.ServiceItems.Include(s => s.Category).ToList();
				bool needsSave = false;
				foreach(var s in servicesToUpdate)
				{
				    if (s.Category != null) {
                        if (salonCategories.Contains(s.Category.Name)) { s.Area = ELGlamPOS.Models.ServiceArea.Salon; needsSave = true; }
                        else if (clinicCategories.Contains(s.Category.Name)) { s.Area = ELGlamPOS.Models.ServiceArea.Clinic; needsSave = true; }
				    }
				}
				if (needsSave) {
				    context.SaveChanges();
				    // Push updated master data immediately to Firebase
				    var masterDataSync = scope.ServiceProvider.GetRequiredService<IFirebaseSyncService>();
				    Task.Run(async () => await masterDataSync.PushMasterDataAsync());
				}
			}
			catch (Exception ex)
			{
				// Log but don't crash — allows app to run even with partial migration issues
				logger?.LogError(ex, "Database migration failed");
			}
		}

		// ── Start Firebase Sync Monitoring ────────────────────────────────────────
		var syncService = app.Services.GetRequiredService<IFirebaseSyncService>();
		syncService.StartMonitoring();

		return app;
	}
}
