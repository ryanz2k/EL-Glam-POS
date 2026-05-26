using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "ServiceItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a068242-4b76-4346-b5c0-aabc42031ff0", "AQAAAAIAAYagAAAAELg3WP+aF+xkH908GJz/iei4sTd8UbyePIAdyhTtzsbcsxkmoElMcVguGLpG9ODcGA==", "2ea9e66f-d673-4791-9780-b4e92c6a885f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40d6267a-f037-4407-a95e-67de530929a5", "AQAAAAIAAYagAAAAEKxkfFtcljZFfNELX04m2FD9axGm0pU6EK5LbGQecZC5in7+Yq45WFWzMoHRTiOhfg==", "0bf9830d-3261-464b-b44b-4ee4222aaa87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9f7bc70-7665-4b9d-8c40-6bdb89d8b4f0", "AQAAAAIAAYagAAAAEBI///f2620nzm7YqK1i/nwcSnOv5DKN4I/apNnpXNc/9DqMKH73IvyrQM60BJdV9g==", "01ce19e3-b2cc-4d6d-8b8c-8f84bb5d0727" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3feebf6d-8322-41ec-b284-3ed52601a332", "AQAAAAIAAYagAAAAEAjXcfIr2vCVl2PfDWkr1ftY6izBbcfW1+A5BT8MVe/Fo+Q/8gdsVuTZinthG2Z5uA==", "428f9d76-1226-4924-b13f-dea7a92e32d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57f5cf7c-268f-4c0d-b91c-06fc3a2a3721", "AQAAAAIAAYagAAAAEJctgjgWonFa3onlCKt6AYEaBMMNguzLlI4TrbDsR4EeVE7Wh2QnBQzUckQ9J73HMw==", "9765e32c-5645-4ee2-a049-e8bfb09a4a70" });

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 21,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 22,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 23,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 24,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 25,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 26,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 27,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 28,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 29,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 30,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 31,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 32,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 33,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 34,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 35,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 36,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 37,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 38,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 39,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 40,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 41,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 42,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 43,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 44,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 45,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 46,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 47,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 48,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 49,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 50,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 51,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 52,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 53,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 54,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 55,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 56,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 57,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 58,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 59,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 60,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 61,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 62,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 63,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 64,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 65,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 66,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 67,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 68,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 69,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 70,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 71,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 72,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 73,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 74,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 75,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 76,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 77,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 78,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 79,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 80,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 81,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 82,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 83,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 84,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 85,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 86,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 87,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 88,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 89,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 90,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 91,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 92,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 93,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 94,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 95,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 96,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 97,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 98,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 99,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 100,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 102,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 103,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 104,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 105,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 106,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 107,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 108,
                column: "Area",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 109,
                column: "Area",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "ServiceItems");

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
        }
    }
}
