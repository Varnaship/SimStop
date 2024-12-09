using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class RenamedTableForShopsCustomerConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsCustomers");

            migrationBuilder.CreateTable(
                name: "ShopsCustomers",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopsCustomers", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_ShopsCustomers_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopsCustomers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopsCustomers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction); // Use NoAction to avoid cycles or multiple cascade paths
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
                name: "IX_ShopsCustomers_CustomerId",
                table: "ShopsCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopsCustomers_ShopId",
                table: "ShopsCustomers",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopsCustomers");

            migrationBuilder.CreateTable(
                name: "ProductsCustomers",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCustomers", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_ProductsCustomers_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCustomers_Products_ProductId",
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
                values: new object[] { "8c2b35e2-8c8e-45d4-bd38-4b6d6a6bdad6", "AQAAAAIAAYagAAAAEBo7dXjyvvgjg8WIZqJM1p1yfV5j6Hlc4XxLOEwCaaJsKnGznm5wIJyAEYOjMs+AFw==", "3ecabd02-3160-4a87-bffc-2f901a695574" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60a7085d-510a-48f4-845b-07e9a0ffbe29", "AQAAAAIAAYagAAAAEG+LY+s2Ap9MaG0zV5iP/1o6dSbFxXMto+w7oLjYXxiu82hCjTLIZrWjvWUtaialmw==", "508cece4-9652-471e-8336-74e53562f76d" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCustomers_CustomerId",
                table: "ProductsCustomers",
                column: "CustomerId");
        }
    }
}

