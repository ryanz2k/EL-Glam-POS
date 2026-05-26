using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class AddFirebaseSyncSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MayaAmount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "GCashAmount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "CashAmount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "BankTransferAmount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "FirebaseKey",
                table: "Transactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSyncedAt",
                table: "Transactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceAppointmentKey",
                table: "Transactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirebaseNameKey",
                table: "Employees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceAppointmentKey",
                table: "DraftOrders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PullOut",
                table: "DailyReports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Expenses",
                table: "DailyReports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "CashAdvance",
                table: "DailyReports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "FirebaseKey",
                table: "DailyReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSyncedAt",
                table: "DailyReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OpeningCashOnHand",
                table: "DailyReports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedAt",
                table: "DailyReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SyncStatus",
                table: "DailyReports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c4714db-7598-4dfc-81a4-42f7eb2a32fc", "AQAAAAIAAYagAAAAEIycw6CDtkoyrL8IsFFJ967ODYxMbIf0UBtgXLGnq5uXRPfLYXW6XNdKiKZw0zyN+w==", "197e9821-14f2-44c5-9b5a-31d0c2f22939" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "714b3295-611a-47cd-9742-6a1daa3eaa85", "AQAAAAIAAYagAAAAEN1O6xl6MiuBeH0jn6OwEG6hJByWZ+mbHzKyFmpl3nHxsoyFUeFPu8lyzf2yGrxTFg==", "2744e35d-1aa9-484c-b6e1-37ce209ff259" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71621dba-81b1-4d36-9b25-976ab5352888", "AQAAAAIAAYagAAAAEO7XGr7RsMPyWpzJxZuAGC6G8SE6leOVQxrTWLmAKWZVOD5wOQooFMhL+Evp2gQcAw==", "63e6ade2-de78-44c8-8d01-d8cb16570b06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c107fd74-66b9-4d9d-8e70-e2334fbc3bcc", "AQAAAAIAAYagAAAAEHrEu4NWfnnpH5/jH7BzmmM1iUQBIH4DuvRk+xW8/bYrJoasA+m3DbxeoOTCM9m0Ag==", "691cbd7d-ebb8-4c01-a074-b409153b43da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40444556-43c6-41be-ad82-321800654685", "AQAAAAIAAYagAAAAEPwAWyfqyQ+JoaMB9Ewf6hNPkiQbSrIrGy2/vyLDgDlc8eSZq0o52A3skFFmgxEWPA==", "fb7c6554-e73e-4892-81b8-4e8290d22343" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20,
                column: "FirebaseNameKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21,
                column: "FirebaseNameKey",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirebaseKey",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastSyncedAt",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SourceAppointmentKey",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FirebaseNameKey",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SourceAppointmentKey",
                table: "DraftOrders");

            migrationBuilder.DropColumn(
                name: "FirebaseKey",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "LastSyncedAt",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "OpeningCashOnHand",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "SubmittedAt",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "DailyReports");

            migrationBuilder.AlterColumn<decimal>(
                name: "MayaAmount",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GCashAmount",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CashAmount",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BankTransferAmount",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PullOut",
                table: "DailyReports",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Expenses",
                table: "DailyReports",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CashAdvance",
                table: "DailyReports",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eb3980f-d378-44b0-baf3-cd898c3f819c", "AQAAAAIAAYagAAAAEFiSPXspuRPpgBOIkFjbZ/S2OD4F5LXk+WYWJSf6cEPmB2UQW1FbngPyFUDrrDLDiw==", "b9209432-8b48-4db5-86f7-522f20826003" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ba8fb14-d772-4d6d-a700-d045705afba0", "AQAAAAIAAYagAAAAENmMQsnVGxwjFcoubar9odpgIqfCsF1me3KIH2N2bU3av4xc/G0s4kF5y+VXaH8YZw==", "1974d008-71b6-4a3b-880c-30f1be4aa5f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a0ef800-7618-4624-b7e7-f6b5c773e850", "AQAAAAIAAYagAAAAELfCyYadnFdNHPC1HzLJlrqmBGT9eT+Gjqhmbd/aDL6huUbJOAtjmexc2xWaT1u+HA==", "3fde9a08-c447-4b60-b0db-a7627b777b87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7980a548-6985-413f-b679-6b79e251a78f", "AQAAAAIAAYagAAAAEKU6cIAnmhsd5ey5oXEgVJPXbyjLLu04Gr3EmXgxS/UIVWDc5mTUpNBoVGJUJUAfpg==", "a9511df2-0153-46a1-956c-3474561fb088" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21aa690e-54fc-4af5-913d-eddd55a206ec", "AQAAAAIAAYagAAAAEJ+/91C5kE9I0hkUTJlJh1lRXOHbdvVv1NTYBzTOPwfnHDlwJs7yqYCoRVbm6iI2NQ==", "61e6f2c2-c598-400d-b926-99f43e2bd0e3" });
        }
    }
}
