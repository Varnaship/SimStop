using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class SimplyfingBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopsProductsDiscounts");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "ShopsProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "ShopsProducts");

            migrationBuilder.CreateTable(
                name: "ShopsProductsDiscounts",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopsProductsDiscounts", x => new { x.ShopId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ShopsProductsDiscounts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopsProductsDiscounts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ShopsProductsDiscounts_ProductId",
                table: "ShopsProductsDiscounts",
                column: "ProductId");
        }
    }
}
