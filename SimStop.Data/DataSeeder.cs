using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimStop.Data;
using SimStop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace SimStop
{
    public static class DataSeeder
    {
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var roles = new[] { "Admin", "ShopAdmin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Seed Users
            var users = new[]
            {
                new { Email = "Admin@SimStop.com", Password = "Admin1234", Role = "Admin" },
                new { Email = "ShopAdmin@SimStop.com", Password = "ShopAdmin1234", Role = "ShopAdmin" },
                new { Email = "User@SimStop.com", Password = "User1234", Role = "User" }
            };

            foreach (var userInfo in users)
            {
                if (await userManager.FindByEmailAsync(userInfo.Email) == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = userInfo.Email,
                        Email = userInfo.Email,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, userInfo.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, userInfo.Role);
                    }
                }
            }
        }

        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Wheel" },
                new Category { Id = 2, CategoryName = "Handbrake" },
                new Category { Id = 3, CategoryName = "Wheel Base" },
                new Category { Id = 4, CategoryName = "Pedals" },
                new Category { Id = 5, CategoryName = "Loadcell Pedals" },
                new Category { Id = 6, CategoryName = "Direct-Drive Wheel Base" },
                new Category { Id = 7, CategoryName = "Sequential Shifter" },
                new Category { Id = 8, CategoryName = "H-Patern Shifter" }
            );
        }

        public static void SeedBrands(this ModelBuilder modelBuilder)
        {
            // Seed Sim Racing Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Logitech G", Description = "Known for their G-series racing wheels and accessories.", FoundedOn = new DateTime(1981, 1, 1) },
                new Brand { Id = 2, Name = "Thrustmaster", Description = "A leading manufacturer of racing wheels, pedals, and accessories.", FoundedOn = new DateTime(1993, 1, 1) },
                new Brand { Id = 3, Name = "Fanatec", Description = "Offers high-end sim racing equipment, including steering wheels, pedals, and seats.", FoundedOn = new DateTime(2005, 1, 1) },
                new Brand { Id = 4, Name = "Simucube", Description = "A premium force feedback system used by professional and serious sim racers.", FoundedOn = new DateTime(2015, 1, 1) },
                new Brand { Id = 5, Name = "Playseat", Description = "Specializes in racing simulators, seats, and stands.", FoundedOn = new DateTime(2003, 1, 1) },
                new Brand { Id = 6, Name = "Heusinkveld", Description = "Known for high-end loadcell pedals and other sim racing peripherals.", FoundedOn = new DateTime(2010, 1, 1) },
                new Brand { Id = 7, Name = "Simagic", Description = "Offers direct-drive wheel bases and other high-performance sim racing gear.", FoundedOn = new DateTime(2018, 1, 1) },
                new Brand { Id = 8, Name = "Next Level Racing", Description = "Provides a range of sim racing cockpits and accessories.", FoundedOn = new DateTime(2009, 1, 1) },
                new Brand { Id = 9, Name = "Cube Controls", Description = "Known for high-quality sim racing steering wheels and button boxes.", FoundedOn = new DateTime(2016, 1, 1) },
                new Brand { Id = 10, Name = "VRS (Virtual Racing School)", Description = "Offers sim racing hardware and coaching services.", FoundedOn = new DateTime(2013, 1, 1) },
                new Brand { Id = 11, Name = "Moza Racing", Description = "Known for high-quality direct-drive wheelbases, steering wheels, and pedals.", FoundedOn = new DateTime(2019, 1, 1) }
            );
        }


        public static void SeedLocations(this ModelBuilder modelBuilder)
        {
            // Seed Towns in Bulgaria
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, LocationName = "Sofia" },
                new Location { Id = 2, LocationName = "Plovdiv" },
                new Location { Id = 3, LocationName = "Varna" },
                new Location { Id = 4, LocationName = "Burgas" },
                new Location { Id = 5, LocationName = "Ruse" }
            );
        }


        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            // Seed Products for each Brand
            modelBuilder.Entity<Product>().HasData(
                // Logitech G Products
                new Product { Id = 1, Name = "Logitech G29", Description = "Racing wheel for PlayStation and PC.", ReleaseDate = new DateTime(2015, 6, 1), Price = 299.99M, Weight = 5.0, CategoryId = 1, BrandId = 1, LocationId = 1, IsDeleted = false },
                new Product { Id = 2, Name = "Logitech G920", Description = "Racing wheel for Xbox and PC.", ReleaseDate = new DateTime(2015, 6, 1), Price = 299.99M, Weight = 5.0, CategoryId = 1, BrandId = 1, LocationId = 2, IsDeleted = false },
                new Product { Id = 3, Name = "Logitech G Pro Pedals", Description = "High-performance pedals for sim racing.", ReleaseDate = new DateTime(2020, 7, 1), Price = 349.99M, Weight = 6.0, CategoryId = 4, BrandId = 1, LocationId = 3, IsDeleted = false },
                new Product { Id = 4, Name = "Logitech G Shifter", Description = "H-pattern shifter for G29 and G920.", ReleaseDate = new DateTime(2015, 6, 1), Price = 59.99M, Weight = 1.5, CategoryId = 8, BrandId = 1, LocationId = 4, IsDeleted = false },
                new Product { Id = 5, Name = "Logitech G923", Description = "Racing wheel with TrueForce feedback.", ReleaseDate = new DateTime(2020, 8, 1), Price = 399.99M, Weight = 5.5, CategoryId = 1, BrandId = 1, LocationId = 5, IsDeleted = false },

                // Thrustmaster Products
                new Product { Id = 6, Name = "Thrustmaster T300 RS", Description = "Racing wheel for PlayStation and PC.", ReleaseDate = new DateTime(2014, 9, 1), Price = 399.99M, Weight = 6.0, CategoryId = 1, BrandId = 2, LocationId = 1, IsDeleted = false },
                new Product { Id = 7, Name = "Thrustmaster TX", Description = "Racing wheel for Xbox and PC.", ReleaseDate = new DateTime(2014, 9, 1), Price = 399.99M, Weight = 6.0, CategoryId = 1, BrandId = 2, LocationId = 2, IsDeleted = false },
                new Product { Id = 8, Name = "Thrustmaster T-LCM Pedals", Description = "Loadcell pedals for sim racing.", ReleaseDate = new DateTime(2020, 3, 1), Price = 199.99M, Weight = 7.0, CategoryId = 5, BrandId = 2, LocationId = 3, IsDeleted = false },
                new Product { Id = 9, Name = "Thrustmaster TH8A Shifter", Description = "H-pattern and sequential shifter.", ReleaseDate = new DateTime(2014, 9, 1), Price = 149.99M, Weight = 2.0, CategoryId = 8, BrandId = 2, LocationId = 4, IsDeleted = false },
                new Product { Id = 10, Name = "Thrustmaster T-GT II", Description = "High-end racing wheel for PlayStation and PC.", ReleaseDate = new DateTime(2021, 6, 1), Price = 799.99M, Weight = 7.5, CategoryId = 1, BrandId = 2, LocationId = 5, IsDeleted = false },

                // Fanatec Products
                new Product { Id = 11, Name = "Fanatec CSL Elite Wheel", Description = "High-performance wheel for sim racing enthusiasts.", ReleaseDate = new DateTime(2019, 5, 1), Price = 499.99M, Weight = 3.5, CategoryId = 1, BrandId = 3, LocationId = 1, IsDeleted = false },
                new Product { Id = 12, Name = "Fanatec ClubSport Pedals V3", Description = "High-end pedals for sim racing.", ReleaseDate = new DateTime(2016, 3, 1), Price = 359.99M, Weight = 5.0, CategoryId = 4, BrandId = 3, LocationId = 2, IsDeleted = false },
                new Product { Id = 13, Name = "Fanatec Podium Wheel Base DD1", Description = "Direct-drive wheel base for sim racing.", ReleaseDate = new DateTime(2018, 12, 1), Price = 1199.99M, Weight = 10.0, CategoryId = 6, BrandId = 3, LocationId = 3, IsDeleted = false },
                new Product { Id = 14, Name = "Fanatec ClubSport Shifter SQ V1.5", Description = "H-pattern and sequential shifter.", ReleaseDate = new DateTime(2016, 3, 1), Price = 259.99M, Weight = 2.5, CategoryId = 8, BrandId = 3, LocationId = 4, IsDeleted = false },
                new Product { Id = 15, Name = "Fanatec CSL DD", Description = "Compact direct-drive wheel base.", ReleaseDate = new DateTime(2021, 8, 1), Price = 349.99M, Weight = 4.0, CategoryId = 6, BrandId = 3, LocationId = 5, IsDeleted = false },

                // Simucube Products
                new Product { Id = 16, Name = "Simucube 2 Pro", Description = "High-end direct-drive wheel base.", ReleaseDate = new DateTime(2019, 5, 1), Price = 1299.99M, Weight = 8.0, CategoryId = 6, BrandId = 4, LocationId = 1, IsDeleted = false },
                new Product { Id = 17, Name = "Simucube 2 Sport", Description = "Mid-range direct-drive wheel base.", ReleaseDate = new DateTime(2019, 5, 1), Price = 899.99M, Weight = 7.0, CategoryId = 6, BrandId = 4, LocationId = 2, IsDeleted = false },
                new Product { Id = 18, Name = "Simucube 2 Ultimate", Description = "Top-of-the-line direct-drive wheel base.", ReleaseDate = new DateTime(2019, 5, 1), Price = 2499.99M, Weight = 9.0, CategoryId = 6, BrandId = 4, LocationId = 3, IsDeleted = false },
                new Product { Id = 19, Name = "Simucube Wireless Wheel", Description = "Wireless steering wheel for Simucube.", ReleaseDate = new DateTime(2020, 6, 1), Price = 499.99M, Weight = 2.0, CategoryId = 1, BrandId = 4, LocationId = 4, IsDeleted = false },
                new Product { Id = 20, Name = "Simucube Pedals", Description = "High-performance pedals for sim racing.", ReleaseDate = new DateTime(2021, 7, 1), Price = 399.99M, Weight = 6.0, CategoryId = 4, BrandId = 4, LocationId = 5, IsDeleted = false },

                // Playseat Products
                new Product { Id = 21, Name = "Playseat Evolution", Description = "Racing simulator seat.", ReleaseDate = new DateTime(2015, 3, 1), Price = 299.99M, Weight = 15.0, CategoryId = 1, BrandId = 5, LocationId = 1, IsDeleted = false },
                new Product { Id = 22, Name = "Playseat Challenge", Description = "Foldable racing simulator seat.", ReleaseDate = new DateTime(2016, 3, 1), Price = 199.99M, Weight = 10.0, CategoryId = 1, BrandId = 5, LocationId = 2, IsDeleted = false },
                new Product { Id = 23, Name = "Playseat Sensation Pro", Description = "High-end racing simulator seat.", ReleaseDate = new DateTime(2018, 3, 1), Price = 999.99M, Weight = 20.0, CategoryId = 1, BrandId = 5, LocationId = 3, IsDeleted = false },
                new Product { Id = 24, Name = "Playseat F1", Description = "Formula 1 racing simulator seat.", ReleaseDate = new DateTime(2017, 3, 1), Price = 1199.99M, Weight = 18.0, CategoryId = 1, BrandId = 5, LocationId = 4, IsDeleted = false },
                new Product { Id = 25, Name = "Playseat Air Force", Description = "Flight simulator seat.", ReleaseDate = new DateTime(2019, 3, 1), Price = 599.99M, Weight = 16.0, CategoryId = 1, BrandId = 5, LocationId = 5, IsDeleted = false },

                // Heusinkveld Products
                new Product { Id = 26, Name = "Heusinkveld Sprint Pedals", Description = "High-end loadcell pedals for precise braking.", ReleaseDate = new DateTime(2020, 9, 5), Price = 899.99M, Weight = 7.2, CategoryId = 5, BrandId = 6, LocationId = 1, IsDeleted = false },
                new Product { Id = 27, Name = "Heusinkveld Ultimate Pedals", Description = "Top-of-the-line loadcell pedals.", ReleaseDate = new DateTime(2018, 3, 1), Price = 1199.99M, Weight = 8.0, CategoryId = 5, BrandId = 6, LocationId = 2, IsDeleted = false },
                new Product { Id = 28, Name = "Heusinkveld Sim Pedals", Description = "Entry-level loadcell pedals.", ReleaseDate = new DateTime(2017, 3, 1), Price = 499.99M, Weight = 6.0, CategoryId = 5, BrandId = 6, LocationId = 3, IsDeleted = false },
                new Product { Id = 29, Name = "Heusinkveld Handbrake", Description = "Loadcell handbrake for sim racing.", ReleaseDate = new DateTime(2019, 3, 1), Price = 299.99M, Weight = 2.0, CategoryId = 2, BrandId = 6, LocationId = 4, IsDeleted = false },
                new Product { Id = 30, Name = "Heusinkveld Sequential Shifter", Description = "Loadcell sequential shifter.", ReleaseDate = new DateTime(2021, 3, 1), Price = 399.99M, Weight = 3.0, CategoryId = 7, BrandId = 6, LocationId = 5, IsDeleted = false },

                // Simagic Products
                new Product { Id = 31, Name = "Simagic Alpha Mini", Description = "Compact direct-drive wheel base with high torque.", ReleaseDate = new DateTime(2022, 11, 10), Price = 799.99M, Weight = 6.8, CategoryId = 6, BrandId = 7, LocationId = 1, IsDeleted = false },
                new Product { Id = 32, Name = "Simagic Alpha", Description = "High-performance direct-drive wheel base.", ReleaseDate = new DateTime(2020, 3, 1), Price = 999.99M, Weight = 7.0, CategoryId = 6, BrandId = 7, LocationId = 2, IsDeleted = false },
                new Product { Id = 33, Name = "Simagic GT1 Wheel", Description = "High-performance GT-style steering wheel.", ReleaseDate = new DateTime(2021, 5, 1), Price = 499.99M, Weight = 2.5, CategoryId = 1, BrandId = 7, LocationId = 3, IsDeleted = false },
                new Product { Id = 34, Name = "Simagic P2000 Pedals", Description = "High-end loadcell pedals.", ReleaseDate = new DateTime(2021, 8, 1), Price = 599.99M, Weight = 7.0, CategoryId = 5, BrandId = 7, LocationId = 4, IsDeleted = false },
                new Product { Id = 35, Name = "Simagic Sequential Shifter", Description = "High-performance sequential shifter.", ReleaseDate = new DateTime(2022, 1, 1), Price = 299.99M, Weight = 3.0, CategoryId = 7, BrandId = 7, LocationId = 5, IsDeleted = false },

                // Next Level Racing Products
                new Product { Id = 36, Name = "Next Level Racing GTtrack", Description = "High-end racing simulator cockpit.", ReleaseDate = new DateTime(2018, 3, 1), Price = 899.99M, Weight = 30.0, CategoryId = 1, BrandId = 8, LocationId = 1, IsDeleted = false },
                new Product { Id = 37, Name = "Next Level Racing F-GT", Description = "Versatile racing simulator cockpit.", ReleaseDate = new DateTime(2017, 3, 1), Price = 499.99M, Weight = 25.0, CategoryId = 1, BrandId = 8, LocationId = 2, IsDeleted = false },
                new Product { Id = 38, Name = "Next Level Racing Wheel Stand", Description = "Adjustable wheel stand for sim racing.", ReleaseDate = new DateTime(2016, 3, 1), Price = 199.99M, Weight = 15.0, CategoryId = 1, BrandId = 8, LocationId = 3, IsDeleted = false },
                new Product { Id = 39, Name = "Next Level Racing Motion Platform", Description = "Motion platform for racing simulators.", ReleaseDate = new DateTime(2019, 3, 1), Price = 2999.99M, Weight = 40.0, CategoryId = 1, BrandId = 8, LocationId = 4, IsDeleted = false },
                new Product { Id = 40, Name = "Next Level Racing Flight Simulator", Description = "Flight simulator cockpit.", ReleaseDate = new DateTime(2020, 3, 1), Price = 599.99M, Weight = 20.0, CategoryId = 1, BrandId = 8, LocationId = 5, IsDeleted = false },

                // Cube Controls Products
                new Product { Id = 41, Name = "Cube Controls Formula Pro", Description = "High-end formula-style steering wheel.", ReleaseDate = new DateTime(2020, 5, 1), Price = 999.99M, Weight = 2.0, CategoryId = 1, BrandId = 9, LocationId = 1, IsDeleted = false },
                new Product { Id = 42, Name = "Cube Controls GT Pro", Description = "High-performance GT-style steering wheel.", ReleaseDate = new DateTime(2020, 5, 1), Price = 899.99M, Weight = 2.5, CategoryId = 1, BrandId = 9, LocationId = 2, IsDeleted = false },
                new Product { Id = 43, Name = "Cube Controls Button Box", Description = "High-quality button box for sim racing.", ReleaseDate = new DateTime(2019, 5, 1), Price = 299.99M, Weight = 1.0, CategoryId = 1, BrandId = 9, LocationId = 3, IsDeleted = false },
                new Product { Id = 44, Name = "Cube Controls Sequential Shifter", Description = "High-performance sequential shifter.", ReleaseDate = new DateTime(2021, 5, 1), Price = 399.99M, Weight = 3.0, CategoryId = 7, BrandId = 9, LocationId = 4, IsDeleted = false },
                new Product { Id = 45, Name = "Cube Controls Pedals", Description = "High-end loadcell pedals.", ReleaseDate = new DateTime(2021, 8, 1), Price = 599.99M, Weight = 7.0, CategoryId = 5, BrandId = 9, LocationId = 5, IsDeleted = false },

                // VRS (Virtual Racing School) Products
                new Product { Id = 46, Name = "VRS DirectForce Pro", Description = "High-end direct-drive wheel base.", ReleaseDate = new DateTime(2020, 5, 1), Price = 999.99M, Weight = 8.0, CategoryId = 6, BrandId = 10, LocationId = 1, IsDeleted = false },
                new Product { Id = 47, Name = "VRS Pedals", Description = "High-performance loadcell pedals.", ReleaseDate = new DateTime(2021, 5, 1), Price = 599.99M, Weight = 7.0, CategoryId = 5, BrandId = 10, LocationId = 2, IsDeleted = false },
                new Product { Id = 48, Name = "VRS Steering Wheel", Description = "High-quality steering wheel for sim racing.", ReleaseDate = new DateTime(2021, 5, 1), Price = 499.99M, Weight = 2.5, CategoryId = 1, BrandId = 10, LocationId = 3, IsDeleted = false },
                new Product { Id = 49, Name = "VRS Sequential Shifter", Description = "High-performance sequential shifter.", ReleaseDate = new DateTime(2022, 1, 1), Price = 299.99M, Weight = 3.0, CategoryId = 7, BrandId = 10, LocationId = 4, IsDeleted = false },
                new Product { Id = 50, Name = "VRS Button Box", Description = "High-quality button box for sim racing.", ReleaseDate = new DateTime(2021, 5, 1), Price = 299.99M, Weight = 1.0, CategoryId = 1, BrandId = 10, LocationId = 5, IsDeleted = false },

                // Moza Racing Products
                new Product { Id = 51, Name = "Moza R9", Description = "High-performance direct-drive wheel base.", ReleaseDate = new DateTime(2021, 5, 1), Price = 799.99M, Weight = 7.0, CategoryId = 6, BrandId = 11, LocationId = 1, IsDeleted = false },
                new Product { Id = 52, Name = "Moza GS Steering Wheel", Description = "High-quality GT-style steering wheel.", ReleaseDate = new DateTime(2021, 5, 1), Price = 499.99M, Weight = 2.5, CategoryId = 1, BrandId = 11, LocationId = 2, IsDeleted = false },
                new Product { Id = 53, Name = "Moza Pedals", Description = "High-end loadcell pedals.", ReleaseDate = new DateTime(2021, 8, 1), Price = 599.99M, Weight = 7.0, CategoryId = 5, BrandId = 11, LocationId = 3, IsDeleted = false },
                new Product { Id = 54, Name = "Moza Sequential Shifter", Description = "High-performance sequential shifter.", ReleaseDate = new DateTime(2022, 1, 1), Price = 299.99M, Weight = 3.0, CategoryId = 7, BrandId = 11, LocationId = 4, IsDeleted = false },
                new Product { Id = 55, Name = "Moza Button Box", Description = "High-quality button box for sim racing.", ReleaseDate = new DateTime(2021, 5, 1), Price = 299.99M, Weight = 1.0, CategoryId = 1, BrandId = 11, LocationId = 5, IsDeleted = false }
            );
        }

        public static async Task SeedShopsAndProducts(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var shopAdmin = await userManager.FindByEmailAsync("ShopAdmin@SimStop.com");
            if (shopAdmin == null)
            {
                throw new Exception("ShopAdmin user not found.");
            }

            if (!context.Shops.Any())
            {
                var brands = context.Brands.ToList();
                var shops = new List<Shop>();

                foreach (var brand in brands)
                {
                    var shop = new Shop
                    {
                        ShopName = brand.Name,
                        LocationId = brands.IndexOf(brand) % 5 + 1, // Cycle through 5 locations
                        OwnerId = shopAdmin.Id,
                        TotalRevenue = 0,
                        IsDeleted = false
                    };

                    var products = context.Products.Where(p => p.BrandId == brand.Id).ToList();
                    var shopProducts = new List<ShopProduct>();

                    foreach (var product in products)
                    {
                        shopProducts.Add(new ShopProduct
                        {
                            Shop = shop,
                            Product = product,
                            Discount = 0
                        });
                    }

                    shop.ShopProducts = shopProducts;
                    shops.Add(shop);
                }

                context.Shops.AddRange(shops);
                await context.SaveChangesAsync();
            }
        }
    }
}
