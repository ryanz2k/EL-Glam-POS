using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e0eb535-21c2-4740-94c7-2c905550f29e", "AQAAAAIAAYagAAAAEBn6sQWQqMnJP2e9ToNlMImCDddMNMk0guDDrocqYkiP6V1J/YbNcXVpIE20ejxi3w==", "0bef63b8-bb77-4ed3-b6d3-93211982747a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "817c33e4-450f-4932-a03b-7ea8b9aa1b86", "AQAAAAIAAYagAAAAEAN9gVJwy/5nY9aZ7C3EzZ+zcXthbkIH4JNMXAtu8mX5k5SMCbnewQ28PMWrOFkLjQ==", "e94744b1-b691-4aa4-aba0-a545cc45c8d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b74f662e-85a2-4af8-accb-c41a93c8b0ec", "AQAAAAIAAYagAAAAEJ9AE6HwYDnBvT1rsGfIahjKzo5eAJrzw0mbQ7+XVgOrPsCc09mlN5FfsusxZ2/utw==", "ae66d99d-6a8e-4563-bbc4-801fdb8de9eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b2a62c4-bfb9-4409-a804-1c1c9e1ed207", "AQAAAAIAAYagAAAAEHM5v1Xb2k7IxiL/Q5/G9O7kzuXGBA1neKXpo3f8fL/JjGaWkd2/yUaMZ02bKnEg3w==", "d2e9b71d-1155-4938-a7fb-14a571dd9dd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0e6c651-fd5d-41a8-8cd7-4ce32557fcf1", "AQAAAAIAAYagAAAAEL35max0AQlH5SAgQ7ybyVJ4peSxHvnMHspgu3d6zaDPSulVAmK2U93Sye9L9o4g+w==", "436b4617-a832-447d-a3b1-a94023a54a08" });

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 54,
                column: "Area",
                value: "Clinic");

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 55,
                column: "Area",
                value: "Salon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 54,
                column: "Area",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceCategories",
                keyColumn: "Id",
                keyValue: 55,
                column: "Area",
                value: "Clinic");
        }
    }
}
