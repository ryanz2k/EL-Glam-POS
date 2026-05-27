using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStartingPriceText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96c1bdc1-3aaf-40c7-9848-4c76e562bfd6", "AQAAAAIAAYagAAAAEEzBoaj0ApnJXWQ7n3v/EQvW7Y0h+U4C+pfL7iBkABYhRYYe4W7S2OBfglf+s9pxwQ==", "e34ffc10-d2dd-44c6-b182-e0afa268190a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57edf706-b3b7-42e9-b59b-61f46e233569", "AQAAAAIAAYagAAAAENzE1k4KXGe9/nkyB/u3fJ/lcSJk1xI6ljLdEaNEhME+1pv1FgqAt5RdxyCdC2K1Bw==", "81df787e-3f04-4b42-83fe-c56e53189964" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da982ed5-1bc5-4dfa-80ad-3f31d95c703d", "AQAAAAIAAYagAAAAENYBFEplulcYIgHfQ7GfYXbCaAkc1buXuUe2Zl4lNvq3+FWjwdRkGDwfbsXDqwU8Lw==", "c3123245-9f2b-4f33-9286-dc7dc7c30456" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1aba530c-fafb-40c6-ada9-8486eff422e8", "AQAAAAIAAYagAAAAEA+jqrcLTtdOaHk4qUSNhvViqYa1F5d/MA04xZ48sXoXM9B85AXHfbAM1E1ShFWEdA==", "95761013-7663-4034-9cca-a66610b4d120" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5eb5ab5d-0955-422a-b317-162c8d291359", "AQAAAAIAAYagAAAAEG5ISq/SScoK28i7RCqgqG+WFOTyY9EO1KKfsulyzNEPTFkSxlx6aEUddYackTjRkQ==", "d1fd3ec3-7464-43c3-88aa-7cc942f868a1" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 293,
                column: "Name",
                value: "Others - Additional Nail Art");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 294,
                column: "Name",
                value: "Others - Stones");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 304,
                column: "Name",
                value: "Special Treatment - Loreal Hair Spa");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 305,
                column: "Name",
                value: "Special Treatment - Plarmia Scalp Treatment");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 306,
                column: "Name",
                value: "Special Treatment - Grand Linkage Damage Repair");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 307,
                column: "Name",
                value: "Special Treatment - Hair Cellophane");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 308,
                column: "Name",
                value: "Special Treatment - Protein Straight Bond");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 309,
                column: "Name",
                value: "Hair Color - Hair Color & Treatment");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 310,
                column: "Name",
                value: "Hair Color - Hair Color, Highlights & Treatment");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 311,
                column: "Name",
                value: "Hair Color - Hair Balayage");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 312,
                column: "Name",
                value: "Rebonding - Regular Hair Rebond");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 313,
                column: "Name",
                value: "Rebonding - Premium Hair Rebond");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 314,
                column: "Name",
                value: "Brazilian Treatment - Brazilian Treatment");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 315,
                column: "Name",
                value: "Beauty Combo - Hair Color, Rebond");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 316,
                column: "Name",
                value: "Beauty Combo - Hair Color, Brazilian");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 317,
                column: "Name",
                value: "Beauty Combo - Hair Color, Rebond, Brazilian Treatment");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 318,
                column: "Name",
                value: "Beauty Combo - Hair Color, Highlights, Rebond, Brazilian Treatment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb9d7385-8b7d-482f-a37d-90a8dc926330", "AQAAAAIAAYagAAAAEF0TUVM+kbiWF+6sHoh45WLyYP3WwCIUI4NvOv2+2AdUk2ViOrwDYcswpretoz5TOg==", "5a6e2fce-0429-4b74-bca5-1493d82d0b0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5172cd8-a445-4894-917c-d81e69bbeff7", "AQAAAAIAAYagAAAAEC76Q5DwIh2BjQyU/zXVQDZi8ndgw02xlSIhMZZVUnrOGvQPIN/QEzYjEr/OBWeCVQ==", "28a3828a-43fb-455b-bc3f-72cb9962584c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e90714c-cfb3-4997-92b9-ba4032255910", "AQAAAAIAAYagAAAAEN8UdgFqyTy1PsRdsFRSTBoYdkNDX5U6R/tauK+Z1gaMuY0oJptEEf1C4g1+vHwJ0w==", "1baf45ae-c450-4305-87fa-6994bfc3d1e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "568976af-3c82-4d11-9d96-a3b53f076a24", "AQAAAAIAAYagAAAAELyloAbHiLdntKap+/PvoO+iWG5PPS+opj2MWo5j5SS+EEaftl+0ShLMsncReMFRgQ==", "f3793c94-dbf9-464a-b84e-b2235b0633bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e0ce7fc-850b-41be-b84d-9ef38450e277", "AQAAAAIAAYagAAAAEOGaBM5MEZl4xIm2AgwH+1YEQ8uRIy6TKzoTxM9Uj4slL5dxaUFcUZaSXxJbT26Dkg==", "f490393a-5e5f-45e4-b1a9-3fad30406849" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 293,
                column: "Name",
                value: "Others - Additional Nail Art (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 294,
                column: "Name",
                value: "Others - Stones (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 304,
                column: "Name",
                value: "Special Treatment - Loreal Hair Spa (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 305,
                column: "Name",
                value: "Special Treatment - Plarmia Scalp Treatment (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 306,
                column: "Name",
                value: "Special Treatment - Grand Linkage Damage Repair (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 307,
                column: "Name",
                value: "Special Treatment - Hair Cellophane (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 308,
                column: "Name",
                value: "Special Treatment - Protein Straight Bond (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 309,
                column: "Name",
                value: "Hair Color - Hair Color & Treatment (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 310,
                column: "Name",
                value: "Hair Color - Hair Color, Highlights & Treatment (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 311,
                column: "Name",
                value: "Hair Color - Hair Balayage (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 312,
                column: "Name",
                value: "Rebonding - Regular Hair Rebond (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 313,
                column: "Name",
                value: "Rebonding - Premium Hair Rebond (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 314,
                column: "Name",
                value: "Brazilian Treatment - Brazilian Treatment (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 315,
                column: "Name",
                value: "Beauty Combo - Hair Color, Rebond (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 316,
                column: "Name",
                value: "Beauty Combo - Hair Color, Brazilian (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 317,
                column: "Name",
                value: "Beauty Combo - Hair Color, Rebond, Brazilian Treatment (starting price)");

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 318,
                column: "Name",
                value: "Beauty Combo - Hair Color, Highlights, Rebond, Brazilian Treatment (starting price)");
        }
    }
}
