using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class ShopAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShopId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Shops",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // Set a default OwnerId for existing records
            migrationBuilder.Sql("UPDATE Shops SET OwnerId = (SELECT TOP 1 Id FROM AspNetUsers)");

            migrationBuilder.CreateTable(
                name: "ShopsProducts",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopsProducts", x => new { x.ShopId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ShopsProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopsProducts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shops_OwnerId",
                table: "Shops",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopsProducts_ProductId",
                table: "ShopsProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_AspNetUsers_OwnerId",
                table: "Shops",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_AspNetUsers_OwnerId",
                table: "Shops");

            migrationBuilder.DropTable(
                name: "ShopsProducts");

            migrationBuilder.DropIndex(
                name: "IX_Shops_OwnerId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Shops");

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShopId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShopId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShopId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShopId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShopId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");
        }
    }
}
