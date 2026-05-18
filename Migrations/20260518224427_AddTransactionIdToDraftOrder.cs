using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionIdToDraftOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "DraftOrders",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_DraftOrders_TransactionId",
                table: "DraftOrders",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftOrders_Transactions_TransactionId",
                table: "DraftOrders",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftOrders_Transactions_TransactionId",
                table: "DraftOrders");

            migrationBuilder.DropIndex(
                name: "IX_DraftOrders_TransactionId",
                table: "DraftOrders");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "DraftOrders");

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
    }
}
