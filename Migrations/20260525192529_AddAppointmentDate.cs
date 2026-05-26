using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELGlamPOS.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDate",
                table: "DraftOrders",
                type: "TEXT",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDate",
                table: "DraftOrders");

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
        }
    }
}
