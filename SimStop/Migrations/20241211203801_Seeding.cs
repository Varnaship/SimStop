using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimStop.Web.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedOn", "Name" },
                values: new object[,]
                {
                    { 6, "Known for high-end loadcell pedals and other sim racing peripherals.", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heusinkveld" },
                    { 7, "Offers direct-drive wheel bases and other high-performance sim racing gear.", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simagic" },
                    { 8, "Provides a range of sim racing cockpits and accessories.", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Next Level Racing" },
                    { 9, "Known for high-quality sim racing steering wheels and button boxes.", new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cube Controls" },
                    { 10, "Offers sim racing hardware and coaching services.", new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VRS (Virtual Racing School)" },
                    { 11, "Known for high-quality direct-drive wheelbases, steering wheels, and pedals.", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moza Racing" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price", "ReleaseDate", "Weight" },
                values: new object[] { "Racing wheel for PlayStation and PC.", "Logitech G29", 299.99m, new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "Description", "Name", "Price", "ReleaseDate", "Weight" },
                values: new object[] { 1, "Racing wheel for Xbox and PC.", "Logitech G920", 299.99m, new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "CategoryId", "Description", "Price", "ReleaseDate", "Weight" },
                values: new object[] { 1, 4, "High-performance pedals for sim racing.", 349.99m, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BrandId", "CategoryId", "Description", "Name", "Price", "ReleaseDate", "Weight" },
                values: new object[] { 1, 8, "H-pattern shifter for G29 and G920.", "Logitech G Shifter", 59.99m, new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BrandId", "CategoryId", "Description", "Name", "Price", "ReleaseDate", "Weight" },
                values: new object[] { 1, 1, "Racing wheel with TrueForce feedback.", "Logitech G923", 399.99m, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.5 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "IsDeleted", "LocationId", "Name", "Price", "ReleaseDate", "Weight" },
                values: new object[,]
                {
                    { 6, 2, 1, "Racing wheel for PlayStation and PC.", false, 1, "Thrustmaster T300 RS", 399.99m, new DateTime(2014, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 },
                    { 7, 2, 1, "Racing wheel for Xbox and PC.", false, 2, "Thrustmaster TX", 399.99m, new DateTime(2014, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 },
                    { 8, 2, 5, "Loadcell pedals for sim racing.", false, 3, "Thrustmaster T-LCM Pedals", 199.99m, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { 9, 2, 8, "H-pattern and sequential shifter.", false, 4, "Thrustmaster TH8A Shifter", 149.99m, new DateTime(2014, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { 10, 2, 1, "High-end racing wheel for PlayStation and PC.", false, 5, "Thrustmaster T-GT II", 799.99m, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5 },
                    { 11, 3, 1, "High-performance wheel for sim racing enthusiasts.", false, 1, "Fanatec CSL Elite Wheel", 499.99m, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.5 },
                    { 12, 3, 4, "High-end pedals for sim racing.", false, 2, "Fanatec ClubSport Pedals V3", 359.99m, new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 },
                    { 13, 3, 6, "Direct-drive wheel base for sim racing.", false, 3, "Fanatec Podium Wheel Base DD1", 1199.99m, new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0 },
                    { 14, 3, 8, "H-pattern and sequential shifter.", false, 4, "Fanatec ClubSport Shifter SQ V1.5", 259.99m, new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5 },
                    { 15, 3, 6, "Compact direct-drive wheel base.", false, 5, "Fanatec CSL DD", 349.99m, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0 },
                    { 16, 4, 6, "High-end direct-drive wheel base.", false, 1, "Simucube 2 Pro", 1299.99m, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0 },
                    { 17, 4, 6, "Mid-range direct-drive wheel base.", false, 2, "Simucube 2 Sport", 899.99m, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { 18, 4, 6, "Top-of-the-line direct-drive wheel base.", false, 3, "Simucube 2 Ultimate", 2499.99m, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0 },
                    { 19, 4, 1, "Wireless steering wheel for Simucube.", false, 4, "Simucube Wireless Wheel", 499.99m, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { 20, 4, 4, "High-performance pedals for sim racing.", false, 5, "Simucube Pedals", 399.99m, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 },
                    { 21, 5, 1, "Racing simulator seat.", false, 1, "Playseat Evolution", 299.99m, new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0 },
                    { 22, 5, 1, "Foldable racing simulator seat.", false, 2, "Playseat Challenge", 199.99m, new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0 },
                    { 23, 5, 1, "High-end racing simulator seat.", false, 3, "Playseat Sensation Pro", 999.99m, new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0 },
                    { 24, 5, 1, "Formula 1 racing simulator seat.", false, 4, "Playseat F1", 1199.99m, new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.0 },
                    { 25, 5, 1, "Flight simulator seat.", false, 5, "Playseat Air Force", 599.99m, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16.0 },
                    { 26, 6, 5, "High-end loadcell pedals for precise braking.", false, 1, "Heusinkveld Sprint Pedals", 899.99m, new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.2000000000000002 },
                    { 27, 6, 5, "Top-of-the-line loadcell pedals.", false, 2, "Heusinkveld Ultimate Pedals", 1199.99m, new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0 },
                    { 28, 6, 5, "Entry-level loadcell pedals.", false, 3, "Heusinkveld Sim Pedals", 499.99m, new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 },
                    { 29, 6, 2, "Loadcell handbrake for sim racing.", false, 4, "Heusinkveld Handbrake", 299.99m, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { 30, 6, 7, "Loadcell sequential shifter.", false, 5, "Heusinkveld Sequential Shifter", 399.99m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                    { 31, 7, 6, "Compact direct-drive wheel base with high torque.", false, 1, "Simagic Alpha Mini", 799.99m, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.7999999999999998 },
                    { 32, 7, 6, "High-performance direct-drive wheel base.", false, 2, "Simagic Alpha", 999.99m, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { 33, 7, 1, "High-performance GT-style steering wheel.", false, 3, "Simagic GT1 Wheel", 499.99m, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5 },
                    { 34, 7, 5, "High-end loadcell pedals.", false, 4, "Simagic P2000 Pedals", 599.99m, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { 35, 7, 7, "High-performance sequential shifter.", false, 5, "Simagic Sequential Shifter", 299.99m, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                    { 36, 8, 1, "High-end racing simulator cockpit.", false, 1, "Next Level Racing GTtrack", 899.99m, new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0 },
                    { 37, 8, 1, "Versatile racing simulator cockpit.", false, 2, "Next Level Racing F-GT", 499.99m, new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0 },
                    { 38, 8, 1, "Adjustable wheel stand for sim racing.", false, 3, "Next Level Racing Wheel Stand", 199.99m, new DateTime(2016, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0 },
                    { 39, 8, 1, "Motion platform for racing simulators.", false, 4, "Next Level Racing Motion Platform", 2999.99m, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.0 },
                    { 40, 8, 1, "Flight simulator cockpit.", false, 5, "Next Level Racing Flight Simulator", 599.99m, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0 },
                    { 41, 9, 1, "High-end formula-style steering wheel.", false, 1, "Cube Controls Formula Pro", 999.99m, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { 42, 9, 1, "High-performance GT-style steering wheel.", false, 2, "Cube Controls GT Pro", 899.99m, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5 },
                    { 43, 9, 1, "High-quality button box for sim racing.", false, 3, "Cube Controls Button Box", 299.99m, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0 },
                    { 44, 9, 7, "High-performance sequential shifter.", false, 4, "Cube Controls Sequential Shifter", 399.99m, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                    { 45, 9, 5, "High-end loadcell pedals.", false, 5, "Cube Controls Pedals", 599.99m, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { 46, 10, 6, "High-end direct-drive wheel base.", false, 1, "VRS DirectForce Pro", 999.99m, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0 },
                    { 47, 10, 5, "High-performance loadcell pedals.", false, 2, "VRS Pedals", 599.99m, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { 48, 10, 1, "High-quality steering wheel for sim racing.", false, 3, "VRS Steering Wheel", 499.99m, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5 },
                    { 49, 10, 7, "High-performance sequential shifter.", false, 4, "VRS Sequential Shifter", 299.99m, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                    { 50, 10, 1, "High-quality button box for sim racing.", false, 5, "VRS Button Box", 299.99m, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0 },
                    { 51, 11, 6, "High-performance direct-drive wheel base.", false, 1, "Moza R9", 799.99m, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { 52, 11, 1, "High-quality GT-style steering wheel.", false, 2, "Moza GS Steering Wheel", 499.99m, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5 },
                    { 53, 11, 5, "High-end loadcell pedals.", false, 3, "Moza Pedals", 599.99m, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { 54, 11, 7, "High-performance sequential shifter.", false, 4, "Moza Sequential Shifter", 299.99m, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                    { 55, 11, 1, "High-quality button box for sim racing.", false, 5, "Moza Button Box", 299.99m, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "5cb3dcff-1d00-4338-aa24-71e92abb7b16", "Kris@SimStop.com", true, false, null, "KRIS@SIMSTOP.COM", "KRIS@SIMSTOP.COM", "AQAAAAIAAYagAAAAEN3c3akgqAzOItrc4lKN40MEVHu0HguRt8fxA6BfEGmRDe3vSWWnTqjXssStr+QjnA==", null, false, "d5c54787-396d-41fb-affd-a0c652d28548", false, "Kris@SimStop.com" },
                    { "2", 0, "e7aa3b3c-fba3-4fbd-877a-a2f5631539d9", "Kris2@SimStop.com", true, false, null, "KRIS2@SIMSTOP.COM", "KRIS2@SIMSTOP.COM", "AQAAAAIAAYagAAAAEBDVSb4biu2286EU1kglj/f9NFHiSkYeTAfWnsz5HsFqtqkEN3YCb4cW2FMlzqFAFQ==", null, false, "76f444aa-e86b-4246-a8c3-21390e7ef68e", false, "Kris2@SimStop.com" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price", "ReleaseDate", "Weight" },
                values: new object[] { "High-performance wheel for sim racing enthusiasts.", "Fanatec CSL Elite Wheel", 499.99m, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "Description", "Name", "Price", "ReleaseDate", "Weight" },
                values: new object[] { 2, "Versatile and affordable wheel for sim racers.", "Thrustmaster T300 RS", 399.99m, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "CategoryId", "Description", "Price", "ReleaseDate", "Weight" },
                values: new object[] { 3, 2, "Precision-engineered pedals for professional sim racers.", 299.99m, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BrandId", "CategoryId", "Description", "Name", "Price", "ReleaseDate", "Weight" },
                values: new object[] { 4, 6, "Compact direct-drive wheel base with high torque.", "Simagic Alpha Mini", 799.99m, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.7999999999999998 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BrandId", "CategoryId", "Description", "Name", "Price", "ReleaseDate", "Weight" },
                values: new object[] { 5, 5, "High-end loadcell pedals for precise braking.", "Heusinkveld Sprint Pedals", 899.99m, new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.2000000000000002 });
        }
    }
}
