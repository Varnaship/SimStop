using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForBrandsAndLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedOn", "Name" },
                values: new object[,]
                {
                    { 1, "Known for their G-series racing wheels and accessories.", new DateTime(1981, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logitech G" },
                    { 2, "A leading manufacturer of racing wheels, pedals, and accessories.", new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thrustmaster" },
                    { 3, "Offers high-end sim racing equipment, including steering wheels, pedals, and seats.", new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fanatec" },
                    { 4, "A premium force feedback system used by professional and serious sim racers.", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simucube" },
                    { 5, "Specializes in racing simulators, seats, and stands.", new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Playseat" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "LocationName" },
                values: new object[,]
                {
                    { 1, "Sofia" },
                    { 2, "Plovdiv" },
                    { 3, "Varna" },
                    { 4, "Burgas" },
                    { 5, "Ruse" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
