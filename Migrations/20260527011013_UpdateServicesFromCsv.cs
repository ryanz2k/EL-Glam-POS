using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateServicesFromCsv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b89e395-b30e-41bd-b3ec-fd9a742b3564", "AQAAAAIAAYagAAAAEDaeWwFaQ+C0FctaxGmz/JHtNbCY9YSjM6JZo/CJR7fQE5ev93qOkTX81cYt23ItQg==", "311fe7c7-3570-4eae-b40a-56312e7461f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6a89a59-f947-437d-ba3e-1f72466703ab", "AQAAAAIAAYagAAAAEAANjPUpZsBZOFFM9HGm7XtJRw+SzzDFRIEnWB6H8p5fza4WzBZZ8NbZPIrGm1YBfQ==", "1b1570ce-2857-4d8d-b50f-e70c49194458" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18dc34ee-567e-48cd-ad7c-ee07076b87dc", "AQAAAAIAAYagAAAAEDtQSZR2wWt+WQct/xj4690JMSy3+mgeG5BS6pxjjlK28cnKUetRe9dC5FUFn1DMjQ==", "4a2497fd-614c-4af1-aa70-f21e5bf9cf1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "753ea486-05f3-492f-b21a-dd6d1338054c", "AQAAAAIAAYagAAAAEAYMGjWlJk6X/MChYpAtTag05P+oaGb9FK6ZP/qMvRM3S410zaHI9+LvstdqA+6nrw==", "82a3c18d-e819-49fc-b348-70b746975310" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6675662-002a-4482-b68b-54bd8a70e0a2", "AQAAAAIAAYagAAAAEOgR6ctZu64ZylkPL0uuwVos30fxxugMq24u8YJPyUGINvhTHU+7fWx9a7SDr3OX4Q==", "e21d3d2b-c7e5-4381-afd1-3a7ea32bcd95" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Gluta Push & Drip");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Eyelash & Brows Care");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Area", "Name" },
                values: new object[] { null, "Semi-Permanent Make Up" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Clinic", "Others (Hair & Make Up)" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Hair Removal");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "IPL/Diode Laser Treatment");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Body Care");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Facial & Body Slimming");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Massage");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Area", "Name" },
                values: new object[] { "Salon", "Nail Care" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Hair Care");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 5, "Eyebrow Micro-Shading (1 Session)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 5, "Eyebrow Micro-Shading (2 Sessions)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 5, "Lips Blush (1 Session)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 5, "Lips Blush (2 Sessions)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 5, "Eyeliner (1 Session)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 5, "Eyeliner (2 Sessions)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 43,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 44,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 45,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 46,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 7, "Arms (Women)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 7, "Legs (Women)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 7, "Arms (Men)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 7, "Legs (Men)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 66,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 67,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 68,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 69,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 70,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 71,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 999.0m, 10, "Trio Slim Treatment Mesotherapy with FREE RF (per vial)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2499.0m, 10, "Slim Boost Therapy with FREE RF (per vial)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 4999.0m, 10, "Ultherapy (Face Area)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 6999.0m, 10, "Ultherapy (other areas)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 599.0m, "Full Body Massage (60mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 399.0m, 11, "Full Body Massage (30mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 349.0m, 11, "Foot Massage (60mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 249.0m, 11, "Foot Massage (30mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 699.0m, 11, "Ventosa Cupping (60mins)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 150.0m, "Regular Polish - Manicure" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 200.0m, 12, "Regular Polish - Pedicure with Soaking" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 450.0m, 12, "Regular Polish - Pedicure with Footspa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 230.0m, 12, "Imported Polish - Manicure" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 300.0m, 12, "Imported Polish - Pedicure with Soaking" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 550.0m, 12, "Imported Polish - Pedicure with Footspa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 12, "Gel Polish - Manicure" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 600.0m, 12, "Gel Polish - Pedicure with Soaking" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 750.0m, 12, "Gel Polish - Pedicure with Footspa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1599.0m, 12, "Nail Extensions - Imported Extensions plain gel polish" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1299.0m, 12, "Nail Extensions - Soft Gel Extensions plain gel polish" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350.0m, 12, "Others - Foot Spa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 30.0m, 12, "Others - Ingrown Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 350.0m, 12, true, "Others - Additional Nail Art (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 10.0m, 12, "Others - Stones (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BasePrice", "IsVariablePrice", "Name" },
                values: new object[] { 200.0m, false, "Men - Haircut" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 300.0m, 13, "Men - Haircut with Shampoo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1000.0m, 13, "Men - Hair Color with Cut" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 13, "Men - Hair Perming" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 250.0m, 13, "Women - Haircut" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350.0m, 13, "Women - Haircut with Shampoo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 13, "Women - Hair Iron" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 13, "Women - Hair Blowdry" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500.0m, 13, "Women - Hair Perming" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 13, true, "Special Treatment - Loreal Hair Spa (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 13, "Special Treatment - Plarmia Scalp Treatment (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2000.0m, 13, "Special Treatment - Grand Linkage Damage Repair (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 800.0m, 13, "Special Treatment - Hair Cellophane (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2500.0m, 13, "Special Treatment - Protein Straight Bond (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500.0m, 13, "Hair Color - Hair Color & Treatment (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2500.0m, 13, "Hair Color - Hair Color, Highlights & Treatment (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3000.0m, 13, "Hair Color - Hair Balayage (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500.0m, 13, "Rebonding - Regular Hair Rebond (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3000.0m, 13, "Rebonding - Premium Hair Rebond (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500.0m, 13, "Brazilian Treatment - Brazilian Treatment (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2500.0m, 13, "Beauty Combo - Hair Color, Rebond (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 13, "Beauty Combo - Hair Color, Brazilian (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3000.0m, 13, "Beauty Combo - Hair Color, Rebond, Brazilian Treatment (starting price)" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3500.0m, 13, "Beauty Combo - Hair Color, Highlights, Rebond, Brazilian Treatment (starting price)" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 3,
                column: "Name",
                value: "Gluta Push and Drip");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Eyelash Care");

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
                column: "Name",
                value: "hair and make up");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Waxing/Threading");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Permanent Hair Removal");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Body Care");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Facial & Body Slimming");

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
                column: "Name",
                value: "Nail Care");

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "Area", "Name" },
                values: new object[] { 14, "Salon", "Hair Care" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 6, "Eyebrow Micro-Shading 1 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 6, "Eyebrow Micro-Shading 2 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 6, "Lips Blush 1 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 6, "Lips Blush 2 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 6, "Eyeliner 1 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 6, "Eyeliner 2 Session" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 43,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 44,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 45,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 46,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 8, "Arms Women" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 8, "Legs Women" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 8, "Arms Men" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 8, "Legs Men" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 66,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 67,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 68,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 69,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 70,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 71,
                column: "CategoryId",
                value: 11);

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
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 6999.0m, "Ultherapy (other areas)" });

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
                columns: new[] { "BasePrice", "Name" },
                values: new object[] { 699.0m, "Ventosa Cupping (60mins)" });

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
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 13, "Imported Polish Pedicure with Footspa" });

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
                columns: new[] { "BasePrice", "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 30.0m, 13, false, "Ingrown Removal" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 350.0m, 13, "Additional Nail Art" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BasePrice", "IsVariablePrice", "Name" },
                values: new object[] { 10.0m, true, "Stones" });

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
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 300.0m, 14, "Men Haircut with Shampoo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 14, "Men Hair Color with Cut" });

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
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 14, "Women Haircut with Shampoo" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 14, "Women Hair Iron" });

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
                columns: new[] { "CategoryId", "IsVariablePrice", "Name" },
                values: new object[] { 14, false, "Women Hair Perming" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 14, "Loreal Hair Spa" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500.0m, 14, "Plarmia Scalp Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2000.0m, 14, "Grand Linkage Damage Repair" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 800.0m, 14, "Hair Cellophane" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2500.0m, 14, "Protein Straight Bond" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500.0m, 14, "Hair Color & Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2500.0m, 14, "Hair Color, Highlights & Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3000.0m, 14, "Hair Balayage" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500.0m, 14, "Regular Hair Rebond" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3000.0m, 14, "Premium Hair Rebond" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 1500.0m, 14, "Brazilian Treatment" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 14, "Hair Color, Rebond" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 2500.0m, 14, "Hair Color, Brazilian" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "BasePrice", "CategoryId", "Name" },
                values: new object[] { 3000.0m, 14, "Hair Color, Rebond, Brazilian Treatment" });

            migrationBuilder.InsertData(
                table: "ServiceItems",
                columns: new[] { "Id", "Area", "BasePrice", "CategoryId", "Description", "ImageUrl", "IsActive", "IsVariablePrice", "Name", "Type" },
                values: new object[] { 120, 0, 3500.0m, 14, "", null, true, true, "Hair Color, Highlights, Rebond, Brazilian Treatment", 0 });
        }
    }
}
