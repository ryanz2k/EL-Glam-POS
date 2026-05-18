using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ELGlamPOS.Data;
using ELGlamPOS.Services;

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
							// Cancel the immediate close
							e.Cancel = true;

							// Dispatch to main thread to show alert
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

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "pos_v2.db");
		builder.Services.AddDbContext<PosDbContext>(options =>
			options.UseSqlite($"Filename={dbPath}"));

#if WINDOWS
		builder.Services.AddSingleton<IReceiptPrinterService, BluetoothReceiptPrinterService>();
#else
		builder.Services.AddSingleton<IReceiptPrinterService, MockReceiptPrinterService>(); // Alternatively Android implementation later
#endif
		builder.Services.AddSingleton<ICommissionCalculatorService, CommissionCalculatorService>();

		builder.Services.AddIdentityCore<Models.ApplicationUser>(options => {
			options.Password.RequireDigit = false;
			options.Password.RequireLowercase = false;
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireUppercase = false;
			options.Password.RequiredLength = 6;
		})
		.AddEntityFrameworkStores<PosDbContext>();

		builder.Services.AddScoped<PosSessionState>();
		builder.Services.AddScoped<CartStateService>();
		builder.Services.AddScoped<Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider, LocalAuthenticationStateProvider>();
		builder.Services.AddAuthorizationCore();

		var app = builder.Build();

		using (var scope = app.Services.CreateScope())
		{
			var context = scope.ServiceProvider.GetRequiredService<PosDbContext>();
			context.Database.EnsureCreated();

            try { context.Database.ExecuteSqlRaw("ALTER TABLE DraftOrders ADD COLUMN DiscountAmount TEXT NOT NULL DEFAULT '0';"); } catch { }
            try { context.Database.ExecuteSqlRaw("ALTER TABLE DraftOrders ADD COLUMN DiscountDescription TEXT NULL;"); } catch { }
            try { context.Database.ExecuteSqlRaw("ALTER TABLE DraftOrders ADD COLUMN PaymentMethod TEXT NULL;"); } 
            catch (Exception ex) { System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "sqlite_error.txt"), ex.ToString()); }

            // Added TransactionId previously
            try { context.Database.ExecuteSqlRaw("ALTER TABLE DraftOrders ADD COLUMN TransactionId INTEGER NULL;"); } catch { }

            try { context.Database.ExecuteSqlRaw("ALTER TABLE Transactions ADD COLUMN CashAmount TEXT NOT NULL DEFAULT '0';"); } catch { }
            try { context.Database.ExecuteSqlRaw("ALTER TABLE Transactions ADD COLUMN GCashAmount TEXT NOT NULL DEFAULT '0';"); } catch { }
            try { context.Database.ExecuteSqlRaw("ALTER TABLE Transactions ADD COLUMN MayaAmount TEXT NOT NULL DEFAULT '0';"); } catch { }
            try { context.Database.ExecuteSqlRaw("ALTER TABLE Transactions ADD COLUMN BankTransferAmount TEXT NOT NULL DEFAULT '0';"); } catch { }

            // Add OpeningCashOnHand to DailyReports
            try { context.Database.ExecuteSqlRaw("ALTER TABLE DailyReports ADD COLUMN OpeningCashOnHand TEXT NOT NULL DEFAULT '0';"); } catch { }

            // Clean up existing order data to reset IDs as requested by user
            try 
            { 
                context.Database.ExecuteSqlRaw("DELETE FROM TransactionItems;"); 
                context.Database.ExecuteSqlRaw("DELETE FROM Transactions;"); 
                context.Database.ExecuteSqlRaw("DELETE FROM DraftOrderItems;"); 
                context.Database.ExecuteSqlRaw("DELETE FROM DraftOrders;"); 
                context.Database.ExecuteSqlRaw("DELETE FROM DailyReports;"); 
                // Reset identity columns
                context.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name IN ('Transactions', 'TransactionItems', 'DraftOrders', 'DraftOrderItems', 'DailyReports');");
            } catch { }

            try
            {
                // Attempt to create DailyReports table gracefully
                context.Database.ExecuteSqlRaw(@"
                    CREATE TABLE IF NOT EXISTS ""DailyReports"" (
                        ""Id"" INTEGER NOT NULL CONSTRAINT ""PK_DailyReports"" PRIMARY KEY AUTOINCREMENT,
                        ""StartDate"" TEXT NOT NULL,
                        ""EndDate"" TEXT NOT NULL,
                        ""BranchId"" INTEGER NOT NULL,
                        ""CashAdvance"" TEXT NOT NULL,
                        ""Expenses"" TEXT NOT NULL,
                        ""PullOut"" TEXT NOT NULL,
                        ""Denom1000"" INTEGER NOT NULL,
                        ""Denom500"" INTEGER NOT NULL,
                        ""Denom200"" INTEGER NOT NULL,
                        ""Denom100"" INTEGER NOT NULL,
                        ""Denom50"" INTEGER NOT NULL,
                        ""Denom20"" INTEGER NOT NULL,
                        ""Denom10"" INTEGER NOT NULL,
                        ""Denom5"" INTEGER NOT NULL,
                        ""Denom1"" INTEGER NOT NULL,
                        CONSTRAINT ""FK_DailyReports_Branches_BranchId"" FOREIGN KEY (""BranchId"") REFERENCES ""Branches"" (""Id"") ON DELETE CASCADE
                    );
                ");
            }
            catch { /* Table likely exists already */ }
		}

		return app;
	}
}
