using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServicesArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "ServiceCategories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fa7093c-9d07-43a2-b3db-47f0daa688a7", "AQAAAAIAAYagAAAAEPmxPWtSXkJresMQ+u/H4vzfuCu29ec7wgaLotPaESdAE4m72tlomL5Kto53NBjXxA==", "be2e8c89-ed19-4038-92de-cacafb3b92fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98ebecd4-31ec-4b66-bfaa-654ef5681ab3", "AQAAAAIAAYagAAAAEFA4WwkFnAubaJnsMNTQDmkDQF0Wlbp7kjU7MWAx4IeEOl0WKfAt4xQVgC9MFevbiA==", "733ad1cd-37e9-4981-801f-05ede1c8939c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53c336b2-b446-474c-94db-3508dbfb0e85", "AQAAAAIAAYagAAAAELwQI5rU3O8jDx65LY9+eIWh52UMWfzgGaGKe6L11lc7nQtTkJEKtRpbOw+/QJFvWQ==", "7c3a2840-ba1a-4218-bb02-909f562e441e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dc26db3-d938-4482-9495-2695f31ce287", "AQAAAAIAAYagAAAAEEOuT8KbUJpNNiovNugsx21bvfXvAYBWCs9uULvEQsynyTmKDZ+ZY1YLYEgCD2jXhg==", "9cf79c3d-f8bd-4c34-8dd8-4b00afc85b74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45abf423-2916-4f77-911c-279265917b41", "AQAAAAIAAYagAAAAEHZcE0aYQFh3K3AKQMNSYGix1ybyIZJhMNq1yi8WTlmBXl18zh9AtY3QbWndjv7MtQ==", "f885f228-9441-4200-9e0b-2eeb250b6e0b" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Area",
                value: "Clinic");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Warts Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Gluta Push and Drip" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Eyelash Care" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Eyebrows Care" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Area", "Name" },
                values: new object[] { null, "Semi-Permanent Make Up" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "hair and make up" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Waxing/Threading" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Permanent Hair Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Body Care" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Facial & Body Slimming" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Message" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Salon", "Nail Care" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Salon", "Hair Care" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "BasePrice",
                value: 549.0m);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 699.0m, "Facial Botox" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 799.0m, "Full Glow Combo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "BasePrice",
                value: 799.0m);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 1299.0m, "Korean BB Glow" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 1499.0m, "Hydra-Facial Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 1499.0m, "Carbon Laser Facial" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 2499.0m, "Melasma Care Treatment (Micro-Needling)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 299.0m, "Vitamin C Shot" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 399.0m, "Gluta IV Push" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499.0m, 3, "Collagen Shot" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499.0m, 3, "Stem Cell" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499.0m, 3, "Placenta" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599.0m, 3, "Glamorous White Shot" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 999.0m, 3, "Express White Drip" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1799.0m, 3, "Snow White Drip" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1899.0m, 3, "Cindella Drip" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1899.0m, 3, "Hikari Drip" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499.0m, 4, "Eyelash Lift" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599.0m, 4, "Eyelash Lift with Tint" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599.0m, 4, "Synthetic Eyelash Extensions" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 799.0m, 4, "Regular Human Hair Eyelash Extensions" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 899.0m, 4, "Ultrasoft Human Hair Eyelash Extensions" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 300.0m, 4, "Eyelash Extensions Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 250.0m, 4, true, "Eyelash Extensions Retouch" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499.0m, 5, "Brow Lamination" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599.0m, 5, "Brow Lamination with tint" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 2999.0m, "Eyebrow Micro-Shading 1 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 4499.0m, "Eyebrow Micro-Shading 2 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2999.0m, 6, "Lips Blush 1 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 4499.0m, 6, "Lips Blush 2 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2499.0m, 6, "Eyeliner 1 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3999.0m, 6, "Eyeliner 2 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 600.0m, 7, "Hairdo/Styling" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 600.0m, 7, "Make Up" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1000.0m, 7, "Hair & Make Up" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 149.0m, 8, "Eyebrows Threading" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 149.0m, 8, "Eyebrows Waxing" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 149.0m, 8, "Upper Mouth" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 149.0m, 8, "Lower Mouth" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 249.0m, 8, "Underarms" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 799.0m, 8, "Brazilian/Bikini Line" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 299.0m, 8, true, "Arms Women" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 499.0m, 8, true, "Legs Women" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 399.0m, 8, "Arms Men" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599.0m, 8, "Legs Men" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 699.0m, 9, false, "Underarm Hair Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 699.0m, 9, false, "Underarm Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 1099.0m, 9, false, "Underarm Hair Removal & Whitening Combo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 399.0m, 9, false, "Lower/Upper Mouth Hair Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 599.0m, 9, false, "Lower & Upper Mouth Combo Hair Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 399.0m, 9, "Arms Hair Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599.0m, 9, "Legs Hair Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 999.0m, 9, false, "Brazilian/Bikini Line Hair Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 899.0m, 9, "Pigmentation Laser" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 899.0m, 9, "Skin Rejuvenating Laser" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 999.0m, 10, "Body Scrub & Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499.0m, 10, "Underarm Whitening (With Diamond Peel)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 899.0m, 10, "Underarm Premium Glow" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599.0m, 10, "Butt/Bikini Line Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1199.0m, 10, "Bikini Premium Glow" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499.0m, 10, "Elbows Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499.0m, 10, "Knees Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499.0m, 11, "RF Facial Contour" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599.0m, 11, "RF with Cavitation (per area)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1599.0m, 11, "RF Arms, Tummy, & Back" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 799.0m, 11, "Trio Slim Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 999.0m, 11, "Mesotherapy with FREE RF (per vial)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2499.0m, 11, "Slim Boost Therapy with FREE RF (per vial)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 4999.0m, 11, "Ultherapy (Face Area)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 6999.0m, 11, "Ultherapy (other areas)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599.0m, 12, "Full Body Massage (60mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 399.0m, 12, "Full Body Massage (30mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 349.0m, 12, "Foot Massage (60mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 249.0m, 12, "Foot Massage (30mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 699.0m, 12, "Ventosa Cupping (60mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 150.0m, 13, "Regular Polish Manicure" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 200.0m, 13, "Regular Polish Pedicure with Soaking" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 450.0m, 13, "Regular Polish Pedicure with Footspa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 230.0m, 13, "Imported Polish Manicure" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 300.0m, 13, "Imported Polish Pedicure with Soaking" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 550.0m, 13, "Imported Polish Pedicure with Footspa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 550.0m, 13, "Gel Polish Manicure" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 600.0m, 13, "Gel Polish Pedicure with Soaking" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 750.0m, 13, "Gel Polish Pedicure with Footspa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1599.0m, 13, "Imported Extensions plain gel polish" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1299.0m, 13, "Soft Gel Extensions plain gel polish" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350.0m, 13, "Foot Spa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 30.0m, 13, "Ingrown Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 350.0m, 13, true, "Additional Nail Art" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 10.0m, 13, true, "Stones" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 200.0m, 14, "Men Haircut" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 300.0m, 14, false, "Men Haircut with Shampoo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 1000.0m, 14, false, "Men Hair Color with Cut" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1000.0m, 14, "Men Hair Perming" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 250.0m, 14, "Women Haircut" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350.0m, 14, "Women Haircut with Shampoo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350.0m, 14, "Women Hair Iron" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350.0m, 14, "Women Hair Blowdry" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 1500.0m, 14, false, "Women Hair Perming" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500.0m, 14, "Loreal Hair Spa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 1500.0m, 14, true, "Plarmia Scalp Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 2000.0m, 14, true, "Grand Linkage Damage Repair" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 800.0m, 14, true, "Hair Cellophane" });

            migrationBuilder.InsertData(
                table: "ServiceItems",
                columns: new[] { "Id", "Area", "BasePrice", "CategoryId", "Description", "ImageUrl", "IsActive", "IsVariablePrice", "Name", "Type" },
                values: new object[,]
                {
                    { 110, 0, 2500.0m, 14, "", null, true, true, "Protein Straight Bond", 0 },
                    { 111, 0, 1500.0m, 14, "", null, true, true, "Hair Color & Treatment", 0 },
                    { 112, 0, 2500.0m, 14, "", null, true, true, "Hair Color, Highlights & Treatment", 0 },
                    { 113, 0, 3000.0m, 14, "", null, true, true, "Hair Balayage", 0 },
                    { 114, 0, 1500.0m, 14, "", null, true, true, "Regular Hair Rebond", 0 },
                    { 115, 0, 3000.0m, 14, "", null, true, true, "Premium Hair Rebond", 0 },
                    { 116, 0, 1500.0m, 14, "", null, true, true, "Brazilian Treatment", 0 },
                    { 117, 0, 2500.0m, 14, "", null, true, true, "Hair Color, Rebond", 0 },
                    { 118, 0, 2500.0m, 14, "", null, true, true, "Hair Color, Brazilian", 0 },
                    { 119, 0, 3000.0m, 14, "", null, true, true, "Hair Color, Rebond, Brazilian Treatment", 0 },
                    { 120, 0, 3500.0m, 14, "", null, true, true, "Hair Color, Highlights, Rebond, Brazilian Treatment", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DropColumn(
                name: "Area",
                table: "ServiceCategories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4188399-fd67-4521-888d-1ff665684ac7", "AQAAAAIAAYagAAAAEITyvBYBwpeFgI+ctdHVWgD1s2Hi6g56YpxJrn9waBsM89SwXbA1KfGahsJE4Q8FVA==", "9dbd0ffb-ef40-4f8b-a79c-fb13aea78768" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e8a5204-ab8a-4c47-9adf-694c2f454ee1", "AQAAAAIAAYagAAAAEPC0XUB/qmG+BPuyY7mGwX6U0lslKInz80eSJahJzDU+GJDlRs/jZQcVcstqBKN3ww==", "716e8fb3-5ce2-4df6-a912-71f8cb9bb336" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9e232e5-17be-4d70-8aa7-0b63459c0ac2", "AQAAAAIAAYagAAAAEENtO1SOsTmUFBH5/2zmRM3g7/+q87NEpNH5ao5iqGlPYlqOoC2f93ZRgS7O+xUHtQ==", "d3d4b112-9a3e-4e1a-a1cc-fbbdc208e3af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b114fe62-c8ec-4301-9379-5a44db44d31d", "AQAAAAIAAYagAAAAENAzSMk21mvAq07odj5mm2ljt+mQXat20/MCUO+OXZs+2lUu9lok59yck3ymI/C8qg==", "796bd649-7543-4da3-a275-c55a266a121b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89dac77c-dfb8-4356-b0a2-059e7187f337", "AQAAAAIAAYagAAAAEIUO043JFgYTY4hocC7AU2qMuSu99vnkfoFckWzWnnzhLM5ar0HPP6Dpk7jBFeWGdA==", "0af9b5c4-975d-4af6-926e-77272815e47d" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Warts removal");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Eyelash Care - Lift");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Eyelash Care - Extensions");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Semi-Permanent Make Up");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Gluta Push & Drip");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Eyebrows Care");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Hair & Make Up");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Hair Care - Men");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Hair Care - Women");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Special Treatment");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Hair Color");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Rebonding");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Brazilian Treatment");

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
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

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "BasePrice",
                value: 499m);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 599m, "Facial Combo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 699m, "Facial Botox" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "BasePrice",
                value: 899m);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 2499m, "Melasma Care Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 1299m, "Korean BB Glow" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 999m, "Hydra-Facial Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 999m, "Carbon Laser Facial" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 499m, "Eyelash Lifting" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 599m, "Eyelash Lifting with Tint" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599m, 4, "Synthetic Eyelashes" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 799m, 4, "Regular Human Hair" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 899m, 4, "Ultrasoft Human Hair" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2499m, 5, "Micro-Shading 1 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3999m, 5, "Micro-Shading 2 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2499m, 5, "Eyeliner 1 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3999m, 5, "Eyeliner 2 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2499m, 5, "Lip Tattoo 1 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3999m, 5, "Lip Tattoo 2 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 199m, 6, "Vitamin C Shot" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 380m, 6, "Collagen Shot" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 380m, 6, "Stem Cell" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 380m, 6, "Gluta I.V. Push" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499m, 6, "Placenta" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 599m, 6, false, "Glamorous White Shot" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 999m, 6, "Express White Drip" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1699m, 6, "Snow White Drip" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 1799m, "Cindella Drip" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 1799m, "Hikari Drip" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 399m, 7, "Brow Lamination" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 449m, 7, "Brow Lamination with Tint" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 500m, 8, "Hairdo/Styling" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 500m, 8, "Make Up" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 800m, 8, "Hair & Make Up" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 150m, 9, "Haircut" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 250m, 9, "Haircut with Shampoo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1000m, 9, "Haircut with Color" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 250m, 10, "Haircut" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350m, 10, "Haircut with Shampoo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350m, 10, "Hair Iron/Blowdry" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500m, 11, "Loreal Power Dose" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500m, 11, "Plarmia Scalp Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 2000m, 11, false, "Grand Linkage" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 800m, 11, false, "Hair Cellophane" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500m, 12, "Hair Color with Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2500m, 12, "Hair Color/Highlights/Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 3000m, 12, true, "Hair Balayage" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 1500m, 13, true, "Regular Hair Rebond" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 3000m, 13, true, "Premium Hair Rebond" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 1500m, 14, true, "Brazilian Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 2500m, 14, true, "Brazilian Treatment + Hair Color" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2500m, 14, "Brazilian Treatment + Hair Rebond" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3000m, 15, "Hair Color/Rebond/Brazilian" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 3500m, 15, true, "Highlights/Color/Rebond/Brazilian" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 999m, 16, "Body Scrub & Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499m, 16, "Underarm Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 899m, 16, "Underarm Premium Glow" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599m, 16, "Butt/Bikini Line Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1199m, 16, "Bikini Premium Glow" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 499m, 16, "Elbows/Knees Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 349m, 17, "RF Facial Contour" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599m, 17, "RF with Cavitation per area" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1499m, 17, "RF Arms/Tummy/Back" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 999m, 17, "Mesotherapy with FREE RF per vial" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3999m, 17, "Ultherapy Face Area" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 5999m, 17, "Ultherapy other areas" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 999m, 17, "Trio Slim" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599m, 18, "Full Body Massage 60 Mins" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 399m, 18, "Full Body Massage 30 Mins" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 349m, 18, "Foot Massage 60 Mins" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 249m, 18, "Foot Massage 30 Mins" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 699m, 18, "Ventosa Cupping 60 Mins" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 150m, 19, "Manicure" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 200m, 19, "Pedicure with Soaking" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 450m, 19, "Pedicure with Footspa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 230m, 20, "Manicure" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 300m, 20, "Pedicure with Soaking" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 550m, 20, "Pedicure with Footspa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 550m, 21, "Manicure" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 600m, 21, "Pedicure with Soaking" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 750m, 21, "Pedicure with Footspa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350m, 21, "Foot Spa Alone" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1599m, 22, "Imported Extensions" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1299m, 22, "Soft Gel Extensions" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350m, 23, "Additional Nail Art" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 10m, 23, "Stones" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 120m, 24, "Eyebrows Threading" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 149m, 24, "Eyebrows Waxing" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 149m, 24, "Upper Mouth" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 149m, 24, false, "Lower Mouth" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 199m, 24, false, "Underarms" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 699m, 24, "Brazilian/Bikini Line" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 299m, 24, true, "Arms - Women" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 499m, 24, true, "Legs - Women" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 699m, 25, "Underarm Hair Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 699m, 25, "Underarm Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1099m, 25, "Underarm Removal & Whitening" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 399m, 25, "Lower/Upper Mouth" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599m, 25, "Lower & Upper Mouth Combo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 399m, 25, true, "Arms" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 599m, 25, "Legs" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 999m, 25, false, "Brazilian/Bikini Line" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 899m, 25, false, "Pigmentation Laser" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 899m, 25, false, "Acne/Skin Rejuvenating Laser" });
        }
    }
}
