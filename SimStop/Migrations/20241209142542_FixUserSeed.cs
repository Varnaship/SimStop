using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18b63028-7e47-4370-8d6f-5a594308beba", "AQAAAAIAAYagAAAAECTQ7gqGLDzvxnDnHVNyftm/2nJ81LqjNJ7gclYmY3P3RKHPOsoaAO5DlyWJ+q0TrQ==", "3fa4a834-39c5-4ef0-99c4-42c2fcded947" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e819b45b-af4e-45eb-9699-c4492001f5d1", "AQAAAAIAAYagAAAAEMDRnJ0fJRNLEDg032Y/2dzJoPRcmfqIz2iQwX2uoih4XENfySrVl8r0HGbfnM41OQ==", "28f80c40-beb5-4bf7-9639-95d5d6d6e21d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6275f769-5f4e-42d4-a833-91897f274825", "AQAAAAIAAYagAAAAECv/kliZV0C4+bwsOsRy/Uj2qr8k3XGFvK+JJsTlYCvVERbOLHw3rOesy0La+s7mwA==", "58136cbf-a1d3-48ad-9ae8-fe1ce27547f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f31f94d3-45c2-4e36-a5b9-e97773a82f12", "AQAAAAIAAYagAAAAEKIt0MOO2v+Z+oEf9w8VyzqvvpIsqRtukRCBCTGy+mmiReS5l3hu76vYhfzbYMBClA==", "ce2dacf0-8366-4f2a-8271-daf9f4c36a11" });
        }
    }
}
