using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class DeletingBundles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BundlesProducts");

            migrationBuilder.DropTable(
                name: "Bundles");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    BundleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.BundleId);
                });

            migrationBuilder.CreateTable(
                name: "BundlesProducts",
                columns: table => new
                {
                    BundleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundlesProducts", x => new { x.BundleId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BundlesProducts_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "BundleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BundlesProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d29e9bf1-2de2-425d-abbd-a8a78ec730dc", "AQAAAAIAAYagAAAAELRrB+QqeNgeJeUx76RiHKddVeulDJP1lZb31nVfNWrjOXra7xmkqgbj2uT/kP2Umw==", "adee71ec-ef74-48d2-a00d-bd3c5e805559" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48b745b5-6061-4127-b671-eb31b043722a", "AQAAAAIAAYagAAAAEHWp6+WZrPLkqGPLdm116wH9XRPJtK/5Niy2rb4ooWLn5KNATAd2gc9vDdH3rpGoaw==", "797ccb01-8976-43d3-8d9a-0d5d2fc68cb2" });

            migrationBuilder.CreateIndex(
                name: "IX_BundlesProducts_ProductId",
                table: "BundlesProducts",
                column: "ProductId");
        }
    }
}
