using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class AddDailyReportAndDraftDiscounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DiscountDescription",
                table: "Transactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DailyReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    CashAdvance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Expenses = table.Column<decimal>(type: "TEXT", nullable: false),
                    PullOut = table.Column<decimal>(type: "TEXT", nullable: false),
                    Denom1000 = table.Column<int>(type: "INTEGER", nullable: false),
                    Denom500 = table.Column<int>(type: "INTEGER", nullable: false),
                    Denom200 = table.Column<int>(type: "INTEGER", nullable: false),
                    Denom100 = table.Column<int>(type: "INTEGER", nullable: false),
                    Denom50 = table.Column<int>(type: "INTEGER", nullable: false),
                    Denom20 = table.Column<int>(type: "INTEGER", nullable: false),
                    Denom10 = table.Column<int>(type: "INTEGER", nullable: false),
                    Denom5 = table.Column<int>(type: "INTEGER", nullable: false),
                    Denom1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReports_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DraftOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerContactNo = table.Column<string>(type: "TEXT", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountDescription = table.Column<string>(type: "TEXT", nullable: true),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedByEmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DraftOrders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DraftOrders_Employees_CreatedByEmployeeId",
                        column: x => x.CreatedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DraftOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DraftOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedEmployeeId = table.Column<int>(type: "INTEGER", nullable: true),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DraftOrderItems_DraftOrders_DraftOrderId",
                        column: x => x.DraftOrderId,
                        principalTable: "DraftOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DraftOrderItems_Employees_AssignedEmployeeId",
                        column: x => x.AssignedEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DraftOrderItems_ServiceItems_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BranchId", "IsActive", "JobTitle", "Name", "Role" },
                values: new object[] { 21, 1, true, "Administrator", "Admin", 2 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5", 0, "d04785fe-8140-4932-b29a-77dd7d5c88ae", "admin@salon.com", false, 21, false, null, "ADMIN@SALON.COM", "ADMIN@SALON.COM", "AQAAAAIAAYagAAAAEMLn+VbRWodHfLOKwaE6c0I4DZYuey3kjXHpD8VKDYjeV6xaK90nhxmPEYWL5bXMpQ==", null, false, "7eb2ce2d-f981-439c-9590-3baecc5094ff", false, "admin@salon.com" });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_BranchId",
                table: "DailyReports",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftOrderItems_AssignedEmployeeId",
                table: "DraftOrderItems",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftOrderItems_DraftOrderId",
                table: "DraftOrderItems",
                column: "DraftOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftOrderItems_ServiceItemId",
                table: "DraftOrderItems",
                column: "ServiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftOrders_BranchId",
                table: "DraftOrders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftOrders_CreatedByEmployeeId",
                table: "DraftOrders",
                column: "CreatedByEmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReports");

            migrationBuilder.DropTable(
                name: "DraftOrderItems");

            migrationBuilder.DropTable(
                name: "DraftOrders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DiscountDescription",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d385c818-f071-4de8-9f97-629a8edad0e4", "AQAAAAIAAYagAAAAEN8g0kNmh5Ti0JoEUDqwZlYrJ+ScuthAUCkKOCuwjAWgG+50grCDvU1VD1IfMdFOOQ==", "9497b8d9-11bf-438a-9dc8-8ba48a6be3a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb5c90fb-08f3-4c7c-b43a-6d19d5706175", "AQAAAAIAAYagAAAAEGzFtTe9/dKz93jL51vodht6v4/G3qDAWIqqGVcH68waRKLU2IK/+hTX7HzxpvzW6w==", "484bc71c-b701-49e9-8f9e-110de3e8ce4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a8deb2b-04d5-4483-9b2b-f953da326f2d", "AQAAAAIAAYagAAAAEHqj87zIrtxyuVSa92xPaaLQ2m5Bpdc7INPwUOKE7wRetw+JI16BGT8HYMa+DR615Q==", "2229d89f-280d-4014-ae26-d8bbdcbade7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae90e1fb-0218-479e-bae0-9f23e542d7b7", "AQAAAAIAAYagAAAAEJjzh92hRmdqvJse5AFguCO/9Z/PODa/H7UgntP7gR62ezIO4ht+GBJiMGAmD22IEA==", "95527fb8-87c9-47db-8cc5-3f9ba0cf1a0d" });
        }
    }
}
