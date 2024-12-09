using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class Seed2Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "6275f769-5f4e-42d4-a833-91897f274825", "Kris@SimStop.com", true, false, null, "KRIS@SIMSTOP.COM", "KRIS@SIMSTOP.COM", "AQAAAAIAAYagAAAAECv/kliZV0C4+bwsOsRy/Uj2qr8k3XGFvK+JJsTlYCvVERbOLHw3rOesy0La+s7mwA==", null, false, "58136cbf-a1d3-48ad-9ae8-fe1ce27547f7", false, "Kris@SimStop.com" },
                    { "2", 0, "f31f94d3-45c2-4e36-a5b9-e97773a82f12", "Kris2@SimStop.com", true, false, null, "KRIS2@SIMSTOP.COM", "KRIS2@SIMSTOP.COM", "AQAAAAIAAYagAAAAEKIt0MOO2v+Z+oEf9w8VyzqvvpIsqRtukRCBCTGy+mmiReS5l3hu76vYhfzbYMBClA==", null, false, "ce2dacf0-8366-4f2a-8271-daf9f4c36a11", false, "Kris2@SimStop.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
