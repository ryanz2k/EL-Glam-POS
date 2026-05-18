using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class AddSplitPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BankTransferAmount",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CashAmount",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GCashAmount",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MayaAmount",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "DraftOrders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "888e25fb-7f58-43fa-ab02-010c49e4ac6c", "AQAAAAIAAYagAAAAEOamWUFnCnsy38SQQDUjGdjWJRf414mcPhfHv66wiPUPtjBIMkcN5SSHs17s75QZLw==", "6d295a61-777e-471b-8c27-0ff2275403a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4f5c410-dfeb-4294-bdea-68f0f4d550d2", "AQAAAAIAAYagAAAAEFY/k7WoawRdzvuyyggchGM6AWyyziul6hCPkuu93jTqfThx8Z06PGihT1wYhOGnZw==", "39450a43-042b-47ab-8e90-320e65e645ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a88dad79-8507-40b3-850b-f31c69cd2354", "AQAAAAIAAYagAAAAECObx4BlHvcaNSn0+RALgFls7O6f7wPphp06IaRyedb60Xof0onHrdQ04ET/BXKxQA==", "5b925eb3-50ff-4597-a16f-72c40dcd3a63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f843bb73-2c6a-44ff-88f9-3f9ae62f484f", "AQAAAAIAAYagAAAAECZAZNn2iL9BIG7cUTUZuo/ejc3UaYi6P/64rxHiutdcB2KBTYuQSAo15mFKr/xpmw==", "f9cd1819-86c1-4e47-854c-a84722c996f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d344c92-c744-4eab-84aa-397fc7835af6", "AQAAAAIAAYagAAAAEFxFdj1BpX9/naJxj8wJ/2rNZtjIDpaQfMl9n1RtdkilaZSMKrDNJFrFQEwTnRQd8A==", "daafd0ac-7242-4057-9367-4fe20403d519" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankTransferAmount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CashAmount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "GCashAmount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "MayaAmount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "DraftOrders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a22429c-9c55-4c60-97c7-dd00d57e5ef7", "AQAAAAIAAYagAAAAEMBqritJX6ujLJzBKrfa6WWi6rvbvBuGvqGjYPsOrp2ezIoOTdV2Em1STPk90PNIyQ==", "8e0e4439-f099-4f8d-906b-91a5cecc1c32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "114876af-bf2a-45b3-8863-12c8da25122f", "AQAAAAIAAYagAAAAEMZwJWaaFxMy1alBTrHhyOMQ6Uq6WADezIMxee1zKLzRzMnC9vdGRjYimiiDVa1Dwg==", "02edc762-79fb-4874-9d19-743f32eb9056" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f492a15-20b5-45cd-8eac-ebe3e4ac6ad6", "AQAAAAIAAYagAAAAEGIuqreyVtmlloyz+ycRJK4POiZgUUDLLxwNofpYtIZSIV5M1LEr0MIvgjnCIIVG/g==", "3a00ba4c-de6d-4884-8980-d946f75a8c52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "897ba94d-efc1-4231-8299-a5efb4b337ce", "AQAAAAIAAYagAAAAELBXJvhUgA6s+czrQFa1IhWIaai0neuVbA1V0Ksc7hzZN5GH4HBKlVfvEgOhit1zJw==", "7ab8ba37-29e5-45cb-88ef-736fbbeb1219" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d04785fe-8140-4932-b29a-77dd7d5c88ae", "AQAAAAIAAYagAAAAEMLn+VbRWodHfLOKwaE6c0I4DZYuey3kjXHpD8VKDYjeV6xaK90nhxmPEYWL5bXMpQ==", "7eb2ce2d-f981-439c-9590-3baecc5094ff" });
        }
    }
}
