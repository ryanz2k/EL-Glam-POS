using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePosFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsVariablePrice = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceItems_ServiceCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommissionRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TargetItemType = table.Column<int>(type: "INTEGER", nullable: true),
                    TargetCategory = table.Column<string>(type: "TEXT", nullable: true),
                    TargetServiceIds = table.Column<string>(type: "TEXT", nullable: true),
                    MinPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommissionRules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentType = table.Column<int>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerContactNo = table.Column<string>(type: "TEXT", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceptionistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Employees_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedEmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceAtTimeOfSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculatedCommission = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionItems_Employees_AssignedEmployeeId",
                        column: x => x.AssignedEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionItems_ServiceItems_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionItems_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mandaue" },
                    { 2, "Pajac" },
                    { 3, "Pusok" },
                    { 4, "Cebu" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Facial Care" },
                    { 2, "Warts removal" },
                    { 3, "Eyelash Care - Lift" },
                    { 4, "Eyelash Care - Extensions" },
                    { 5, "Semi-Permanent Make Up" },
                    { 6, "Gluta Push & Drip" },
                    { 7, "Eyebrows Care" },
                    { 8, "Hair & Make Up" },
                    { 9, "Hair Care - Men" },
                    { 10, "Hair Care - Women" },
                    { 11, "Special Treatment" },
                    { 12, "Hair Color" },
                    { 13, "Rebonding" },
                    { 14, "Brazilian Treatment" },
                    { 15, "Combo" },
                    { 16, "Body Care" },
                    { 17, "Facial & Body Slimming" },
                    { 18, "Massage" },
                    { 19, "Nail Care - Regular Polish" },
                    { 20, "Nail Care - Imported Polish" },
                    { 21, "Nail Care - Gel Polish" },
                    { 22, "Nail Extensions" },
                    { 23, "Others" },
                    { 24, "Waxing/Threading" },
                    { 25, "Permanent Hair Removal" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BranchId", "IsActive", "JobTitle", "Name", "Role" },
                values: new object[,]
                {
                    { 1, 1, true, "Receptionist", "Jesa Mae Basi", 0 },
                    { 2, 1, true, "Facialist", "Sanny Grace Yekla", 1 },
                    { 3, 1, true, "Nail Technician", "Rosegina Davis", 1 },
                    { 4, 1, true, "Facialist", "Ruthamie Momo", 1 },
                    { 5, 1, true, "Nail Technician", "Imae Rose Dela Torre", 1 },
                    { 6, 1, true, "Hair Stylist", "Jennipher Yaon", 1 },
                    { 7, 2, true, "Receptionist", "Marilyn Teves", 0 },
                    { 8, 2, true, "Facialist", "Mattlaine Clyrr Belarmino", 1 },
                    { 9, 2, true, "Nail Technician", "Jenalyn Entig", 1 },
                    { 10, 2, true, "Hair Stylist/Nail Tech", "Buenafe Arnado", 1 },
                    { 11, 2, true, "Hair Stylist/Nail Tech", "Elvira Omac", 1 },
                    { 12, 2, true, "Barber", "Keyn Joshua Demane", 1 },
                    { 13, 3, true, "Nail Technician", "Rowena Pedor", 1 },
                    { 14, 3, true, "Facialist", "Julie Ann Abadajos", 1 },
                    { 15, 3, true, "Hair Stylist", "Janeth Dimco", 1 },
                    { 16, 4, true, "Nail Technician", "Jennifer Cabreles", 1 },
                    { 17, 4, true, "Nail Technician", "Jessica Macatanong", 1 },
                    { 18, 4, true, "Facialist", "Rubelyn Cañizares", 1 },
                    { 19, 4, true, "Facialist", "Jeanny Dela Torre", 1 },
                    { 20, 4, true, "Hair Stylist", "Lucille Tailo", 1 }
                });

            migrationBuilder.InsertData(
                table: "ServiceItems",
                columns: new[] { "Id", "BasePrice", "CategoryId", "Description", "ImageUrl", "IsActive", "IsVariablePrice", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 399m, 1, "", null, true, false, "Signature Facial", 0 },
                    { 2, 499m, 1, "", null, true, false, "Facial with Diamond Peel", 0 },
                    { 3, 599m, 1, "", null, true, false, "Facial Combo", 0 },
                    { 4, 699m, 1, "", null, true, false, "Facial Botox", 0 },
                    { 5, 899m, 1, "", null, true, false, "Acne Control Treatment", 0 },
                    { 6, 999m, 1, "", null, true, false, "Backcial", 0 },
                    { 7, 2499m, 1, "", null, true, false, "Melasma Care Treatment", 0 },
                    { 8, 1299m, 1, "", null, true, false, "Korean BB Glow", 0 },
                    { 9, 999m, 1, "", null, true, false, "Hydra-Facial Treatment", 0 },
                    { 10, 999m, 1, "", null, true, false, "Carbon Laser Facial", 0 },
                    { 11, 799m, 2, "", null, true, false, "Unlimited Face Area", 0 },
                    { 12, 799m, 2, "", null, true, false, "Unlimited Neck Area", 0 },
                    { 13, 1499m, 2, "", null, true, false, "Unlimited Face & Neck Area", 0 },
                    { 14, 499m, 3, "", null, true, false, "Eyelash Lifting", 0 },
                    { 15, 599m, 3, "", null, true, false, "Eyelash Lifting with Tint", 0 },
                    { 16, 599m, 4, "", null, true, false, "Synthetic Eyelashes", 0 },
                    { 17, 799m, 4, "", null, true, false, "Regular Human Hair", 0 },
                    { 18, 899m, 4, "", null, true, false, "Ultrasoft Human Hair", 0 },
                    { 19, 2499m, 5, "", null, true, false, "Micro-Shading 1 Session", 0 },
                    { 20, 3999m, 5, "", null, true, false, "Micro-Shading 2 Session", 0 },
                    { 21, 2499m, 5, "", null, true, false, "Eyeliner 1 Session", 0 },
                    { 22, 3999m, 5, "", null, true, false, "Eyeliner 2 Session", 0 },
                    { 23, 2499m, 5, "", null, true, false, "Lip Tattoo 1 Session", 0 },
                    { 24, 3999m, 5, "", null, true, false, "Lip Tattoo 2 Session", 0 },
                    { 25, 199m, 6, "", null, true, false, "Vitamin C Shot", 0 },
                    { 26, 380m, 6, "", null, true, false, "Collagen Shot", 0 },
                    { 27, 380m, 6, "", null, true, false, "Stem Cell", 0 },
                    { 28, 380m, 6, "", null, true, false, "Gluta I.V. Push", 0 },
                    { 29, 499m, 6, "", null, true, false, "Placenta", 0 },
                    { 30, 599m, 6, "", null, true, false, "Glamorous White Shot", 0 },
                    { 31, 999m, 6, "", null, true, false, "Express White Drip", 0 },
                    { 32, 1699m, 6, "", null, true, false, "Snow White Drip", 0 },
                    { 33, 1799m, 6, "", null, true, false, "Cindella Drip", 0 },
                    { 34, 1799m, 6, "", null, true, false, "Hikari Drip", 0 },
                    { 35, 399m, 7, "", null, true, false, "Brow Lamination", 0 },
                    { 36, 449m, 7, "", null, true, false, "Brow Lamination with Tint", 0 },
                    { 37, 500m, 8, "", null, true, false, "Hairdo/Styling", 0 },
                    { 38, 500m, 8, "", null, true, false, "Make Up", 0 },
                    { 39, 800m, 8, "", null, true, false, "Hair & Make Up", 0 },
                    { 40, 150m, 9, "", null, true, false, "Haircut", 0 },
                    { 41, 250m, 9, "", null, true, false, "Haircut with Shampoo", 0 },
                    { 42, 1000m, 9, "", null, true, false, "Haircut with Color", 0 },
                    { 43, 250m, 10, "", null, true, false, "Haircut", 0 },
                    { 44, 350m, 10, "", null, true, false, "Haircut with Shampoo", 0 },
                    { 45, 350m, 10, "", null, true, false, "Hair Iron/Blowdry", 0 },
                    { 46, 1500m, 11, "", null, true, false, "Loreal Power Dose", 0 },
                    { 47, 1500m, 11, "", null, true, false, "Plarmia Scalp Treatment", 0 },
                    { 48, 2000m, 11, "", null, true, false, "Grand Linkage", 0 },
                    { 49, 800m, 11, "", null, true, false, "Hair Cellophane", 0 },
                    { 50, 1500m, 12, "", null, true, true, "Hair Color with Treatment", 0 },
                    { 51, 2500m, 12, "", null, true, true, "Hair Color/Highlights/Treatment", 0 },
                    { 52, 3000m, 12, "", null, true, true, "Hair Balayage", 0 },
                    { 53, 1500m, 13, "", null, true, true, "Regular Hair Rebond", 0 },
                    { 54, 3000m, 13, "", null, true, true, "Premium Hair Rebond", 0 },
                    { 55, 1500m, 14, "", null, true, true, "Brazilian Treatment", 0 },
                    { 56, 2500m, 14, "", null, true, true, "Brazilian Treatment + Hair Color", 0 },
                    { 57, 2500m, 14, "", null, true, true, "Brazilian Treatment + Hair Rebond", 0 },
                    { 58, 3000m, 15, "", null, true, true, "Hair Color/Rebond/Brazilian", 0 },
                    { 59, 3500m, 15, "", null, true, true, "Highlights/Color/Rebond/Brazilian", 0 },
                    { 60, 999m, 16, "", null, true, false, "Body Scrub & Whitening", 0 },
                    { 61, 499m, 16, "", null, true, false, "Underarm Whitening", 0 },
                    { 62, 899m, 16, "", null, true, false, "Underarm Premium Glow", 0 },
                    { 63, 599m, 16, "", null, true, false, "Butt/Bikini Line Whitening", 0 },
                    { 64, 1199m, 16, "", null, true, false, "Bikini Premium Glow", 0 },
                    { 65, 499m, 16, "", null, true, false, "Elbows/Knees Whitening", 0 },
                    { 66, 349m, 17, "", null, true, false, "RF Facial Contour", 0 },
                    { 67, 599m, 17, "", null, true, false, "RF with Cavitation per area", 0 },
                    { 68, 1499m, 17, "", null, true, false, "RF Arms/Tummy/Back", 0 },
                    { 69, 999m, 17, "", null, true, false, "Mesotherapy with FREE RF per vial", 0 },
                    { 70, 3999m, 17, "", null, true, false, "Ultherapy Face Area", 0 },
                    { 71, 5999m, 17, "", null, true, false, "Ultherapy other areas", 0 },
                    { 72, 999m, 17, "", null, true, false, "Trio Slim", 0 },
                    { 73, 599m, 18, "", null, true, false, "Full Body Massage 60 Mins", 0 },
                    { 74, 399m, 18, "", null, true, false, "Full Body Massage 30 Mins", 0 },
                    { 75, 349m, 18, "", null, true, false, "Foot Massage 60 Mins", 0 },
                    { 76, 249m, 18, "", null, true, false, "Foot Massage 30 Mins", 0 },
                    { 77, 699m, 18, "", null, true, false, "Ventosa Cupping 60 Mins", 0 },
                    { 78, 150m, 19, "", null, true, false, "Manicure", 0 },
                    { 79, 200m, 19, "", null, true, false, "Pedicure with Soaking", 0 },
                    { 80, 450m, 19, "", null, true, false, "Pedicure with Footspa", 0 },
                    { 81, 230m, 20, "", null, true, false, "Manicure", 0 },
                    { 82, 300m, 20, "", null, true, false, "Pedicure with Soaking", 0 },
                    { 83, 550m, 20, "", null, true, false, "Pedicure with Footspa", 0 },
                    { 84, 550m, 21, "", null, true, false, "Manicure", 0 },
                    { 85, 600m, 21, "", null, true, false, "Pedicure with Soaking", 0 },
                    { 86, 750m, 21, "", null, true, false, "Pedicure with Footspa", 0 },
                    { 87, 350m, 21, "", null, true, false, "Foot Spa Alone", 0 },
                    { 88, 1599m, 22, "", null, true, false, "Imported Extensions", 0 },
                    { 89, 1299m, 22, "", null, true, false, "Soft Gel Extensions", 0 },
                    { 90, 350m, 23, "", null, true, false, "Additional Nail Art", 0 },
                    { 91, 10m, 23, "", null, true, false, "Stones", 0 },
                    { 92, 120m, 24, "", null, true, false, "Eyebrows Threading", 0 },
                    { 93, 149m, 24, "", null, true, false, "Eyebrows Waxing", 0 },
                    { 94, 149m, 24, "", null, true, false, "Upper Mouth", 0 },
                    { 95, 149m, 24, "", null, true, false, "Lower Mouth", 0 },
                    { 96, 199m, 24, "", null, true, false, "Underarms", 0 },
                    { 97, 699m, 24, "", null, true, false, "Brazilian/Bikini Line", 0 },
                    { 98, 299m, 24, "", null, true, true, "Arms - Women", 0 },
                    { 99, 499m, 24, "", null, true, true, "Legs - Women", 0 },
                    { 100, 699m, 25, "", null, true, false, "Underarm Hair Removal", 0 },
                    { 101, 699m, 25, "", null, true, false, "Underarm Whitening", 0 },
                    { 102, 1099m, 25, "", null, true, false, "Underarm Removal & Whitening", 0 },
                    { 103, 399m, 25, "", null, true, false, "Lower/Upper Mouth", 0 },
                    { 104, 599m, 25, "", null, true, false, "Lower & Upper Mouth Combo", 0 },
                    { 105, 399m, 25, "", null, true, true, "Arms", 0 },
                    { 106, 599m, 25, "", null, true, true, "Legs", 0 },
                    { 107, 999m, 25, "", null, true, false, "Brazilian/Bikini Line", 0 },
                    { 108, 899m, 25, "", null, true, false, "Pigmentation Laser", 0 },
                    { 109, 899m, 25, "", null, true, false, "Acne/Skin Rejuvenating Laser", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "d385c818-f071-4de8-9f97-629a8edad0e4", "jesa@salon.com", false, 1, false, null, "JESA@SALON.COM", "JESA@SALON.COM", "AQAAAAIAAYagAAAAEN8g0kNmh5Ti0JoEUDqwZlYrJ+ScuthAUCkKOCuwjAWgG+50grCDvU1VD1IfMdFOOQ==", null, false, "9497b8d9-11bf-438a-9dc8-8ba48a6be3a8", false, "jesa@salon.com" },
                    { "2", 0, "bb5c90fb-08f3-4c7c-b43a-6d19d5706175", "marilyn@salon.com", false, 7, false, null, "MARILYN@SALON.COM", "MARILYN@SALON.COM", "AQAAAAIAAYagAAAAEGzFtTe9/dKz93jL51vodht6v4/G3qDAWIqqGVcH68waRKLU2IK/+hTX7HzxpvzW6w==", null, false, "484bc71c-b701-49e9-8f9e-110de3e8ce4e", false, "marilyn@salon.com" },
                    { "3", 0, "6a8deb2b-04d5-4483-9b2b-f953da326f2d", "rowena@salon.com", false, 13, false, null, "ROWENA@SALON.COM", "ROWENA@SALON.COM", "AQAAAAIAAYagAAAAEHqj87zIrtxyuVSa92xPaaLQ2m5Bpdc7INPwUOKE7wRetw+JI16BGT8HYMa+DR615Q==", null, false, "2229d89f-280d-4014-ae26-d8bbdcbade7e", false, "rowena@salon.com" },
                    { "4", 0, "ae90e1fb-0218-479e-bae0-9f23e542d7b7", "jennifer@salon.com", false, 16, false, null, "JENNIFER@SALON.COM", "JENNIFER@SALON.COM", "AQAAAAIAAYagAAAAEJjzh92hRmdqvJse5AFguCO/9Z/PODa/H7UgntP7gR62ezIO4ht+GBJiMGAmD22IEA==", null, false, "95527fb8-87c9-47db-8cc5-3f9ba0cf1a0d", false, "jennifer@salon.com" }
                });

            migrationBuilder.InsertData(
                table: "CommissionRules",
                columns: new[] { "Id", "EmployeeId", "MaxPrice", "MinPrice", "Percentage", "Priority", "TargetCategory", "TargetItemType", "TargetServiceIds" },
                values: new object[,]
                {
                    { 1, 2, null, null, 40m, 10, "Massage", 0, null },
                    { 2, 2, null, null, 10m, 10, "Injectables", 0, null },
                    { 3, 2, null, null, 10m, 5, null, 1, null },
                    { 4, 3, null, null, 5m, 1, null, 0, null },
                    { 5, 3, null, null, 40m, 10, "Massage", 0, null },
                    { 6, 3, null, null, 10m, 5, null, 1, null },
                    { 7, 3, null, null, 8m, 10, "Hair", 0, null },
                    { 8, 4, null, null, 5m, 1, null, 0, null },
                    { 9, 4, null, null, 10m, 2, null, null, null },
                    { 10, 5, null, null, 5m, 1, null, null, null },
                    { 11, 6, null, null, 10m, 1, null, null, null },
                    { 12, 8, null, null, 20m, 10, "Microshading", 0, null },
                    { 13, 8, null, null, 10m, 5, null, 1, null },
                    { 14, 8, null, 1000m, 8m, 5, null, 0, null },
                    { 15, 9, 998.99m, null, 5m, 1, null, 0, null },
                    { 16, 9, null, null, 10m, 5, null, 1, null },
                    { 17, 9, null, 499m, 10m, 10, null, 0, null },
                    { 18, 9, null, null, 5m, 2, null, 0, null },
                    { 19, 10, null, null, 10m, 1, null, null, null },
                    { 20, 11, null, null, 10m, 1, null, null, null },
                    { 21, 12, null, null, 50m, 1, null, 0, null },
                    { 22, 13, null, null, 10m, 5, null, 1, null },
                    { 23, 13, null, null, 5m, 1, null, 0, null },
                    { 24, 13, null, 499m, 10m, 10, null, 0, null },
                    { 25, 14, null, null, 10m, 5, null, 1, null },
                    { 26, 14, null, null, 5m, 1, null, 0, null },
                    { 27, 15, null, null, 10m, 1, null, null, null },
                    { 28, 16, null, null, 5m, 1, null, null, null },
                    { 29, 17, null, null, 5m, 1, null, 0, null },
                    { 30, 17, null, null, 10m, 5, null, 1, null },
                    { 31, 18, null, null, 10m, 10, "Massage", 0, null },
                    { 32, 18, null, null, 5m, 1, null, 0, null },
                    { 33, 19, null, null, 10m, 10, "Massage", 0, null },
                    { 34, 19, null, null, 5m, 1, null, 0, null },
                    { 35, 20, null, null, 5m, 1, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommissionRules_EmployeeId",
                table: "CommissionRules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItems_CategoryId",
                table: "ServiceItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_AssignedEmployeeId",
                table: "TransactionItems",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_ServiceItemId",
                table: "TransactionItems",
                column: "ServiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_TransactionId",
                table: "TransactionItems",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BranchId",
                table: "Transactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceptionistId",
                table: "Transactions",
                column: "ReceptionistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CommissionRules");

            migrationBuilder.DropTable(
                name: "TransactionItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ServiceItems");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
