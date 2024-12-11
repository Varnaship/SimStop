using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteOnShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Shops",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cb3dcff-1d00-4338-aa24-71e92abb7b16", "AQAAAAIAAYagAAAAEN3c3akgqAzOItrc4lKN40MEVHu0HguRt8fxA6BfEGmRDe3vSWWnTqjXssStr+QjnA==", "d5c54787-396d-41fb-affd-a0c652d28548" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7aa3b3c-fba3-4fbd-877a-a2f5631539d9", "AQAAAAIAAYagAAAAEBDVSb4biu2286EU1kglj/f9NFHiSkYeTAfWnsz5HsFqtqkEN3YCb4cW2FMlzqFAFQ==", "76f444aa-e86b-4246-a8c3-21390e7ef68e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Shops");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2e52bd6-7fb8-4a55-81ee-82f44d3a0a78", "AQAAAAIAAYagAAAAEOH4S5vs9mGtmjBl/g1U7CD2/0A2Jd1A3kQuZiY5lqmJJofF2x53yt1HjjT4QUCUHA==", "df734c62-219e-42d3-9585-44acf4ef3191" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c46617ba-3ad7-4849-ac13-9809dbac6d5c", "AQAAAAIAAYagAAAAEHOjqVTggIoV8Z+/BkCi9N0nYRTpN9NbfIqija5HHdRN11cpilWEplLLQtfIbj/MHQ==", "6eb785cc-b5db-4108-af4d-9b1746a5be94" });
        }
    }
}
