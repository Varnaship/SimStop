using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class seedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "IsDeleted", "LocationId", "Name", "Price", "ReleaseDate", "ShopId", "Weight" },
                values: new object[,]
                {
                    { 1, 1, 1, "High-performance wheel for sim racing enthusiasts.", false, 1, "Fanatec CSL Elite Wheel", 499.99m, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3.5 },
                    { 2, 2, 1, "Versatile and affordable wheel for sim racers.", false, 2, "Thrustmaster T300 RS", 399.99m, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4.2000000000000002 },
                    { 3, 3, 2, "Precision-engineered pedals for professional sim racers.", false, 3, "Logitech G Pro Pedals", 299.99m, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5.0 },
                    { 4, 4, 6, "Compact direct-drive wheel base with high torque.", false, 4, "Simagic Alpha Mini", 799.99m, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6.7999999999999998 },
                    { 5, 5, 5, "High-end loadcell pedals for precise braking.", false, 5, "Heusinkveld Sprint Pedals", 899.99m, new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7.2000000000000002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
