using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimStop.Data.Models;

namespace SimStop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

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

            // Seed Sim Racing Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Logitech G", Description = "Known for their G-series racing wheels and accessories.", FoundedOn = new DateTime(1981, 1, 1) },
                new Brand { Id = 2, Name = "Thrustmaster", Description = "A leading manufacturer of racing wheels, pedals, and accessories.", FoundedOn = new DateTime(1993, 1, 1) },
                new Brand { Id = 3, Name = "Fanatec", Description = "Offers high-end sim racing equipment, including steering wheels, pedals, and seats.", FoundedOn = new DateTime(2005, 1, 1) },
                new Brand { Id = 4, Name = "Simucube", Description = "A premium force feedback system used by professional and serious sim racers.", FoundedOn = new DateTime(2015, 1, 1) },
                new Brand { Id = 5, Name = "Playseat", Description = "Specializes in racing simulators, seats, and stands.", FoundedOn = new DateTime(2003, 1, 1) }
            );

            // Seed Towns in Bulgaria
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, LocationName = "Sofia" },
                new Location { Id = 2, LocationName = "Plovdiv" },
                new Location { Id = 3, LocationName = "Varna" },
                new Location { Id = 4, LocationName = "Burgas" },
                new Location { Id = 5, LocationName = "Ruse" }
            );

            // Products Seed
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Fanatec CSL Elite Wheel",
                    Description = "High-performance wheel for sim racing enthusiasts.",
                    ReleaseDate = new DateTime(2019, 5, 1),
                    Price = 499.99M,
                    Weight = 3.5,
                    CategoryId = 1, // Wheel
                    BrandId = 1,    // Fanatec
                    LocationId = 1, // Sofia
                    IsDeleted = false
                },
                new Product
                {
                    Id = 2,
                    Name = "Thrustmaster T300 RS",
                    Description = "Versatile and affordable wheel for sim racers.",
                    ReleaseDate = new DateTime(2020, 3, 15),
                    Price = 399.99M,
                    Weight = 4.2,
                    CategoryId = 1, // Wheel
                    BrandId = 2,    // Thrustmaster
                    LocationId = 2, // Plovdiv
                    IsDeleted = false
                },
                new Product
                {
                    Id = 3,
                    Name = "Logitech G Pro Pedals",
                    Description = "Precision-engineered pedals for professional sim racers.",
                    ReleaseDate = new DateTime(2021, 7, 20),
                    Price = 299.99M,
                    Weight = 5.0,
                    CategoryId = 2, // Pedals
                    BrandId = 3,    // Logitech
                    LocationId = 3, // Varna
                    IsDeleted = false
                },
                new Product
                {
                    Id = 4,
                    Name = "Simagic Alpha Mini",
                    Description = "Compact direct-drive wheel base with high torque.",
                    ReleaseDate = new DateTime(2022, 11, 10),
                    Price = 799.99M,
                    Weight = 6.8,
                    CategoryId = 6, // Direct-Drive Wheel Base
                    BrandId = 4,    // Simagic
                    LocationId = 4, // Burgas
                    IsDeleted = false
                },
                new Product
                {
                    Id = 5,
                    Name = "Heusinkveld Sprint Pedals",
                    Description = "High-end loadcell pedals for precise braking.",
                    ReleaseDate = new DateTime(2020, 9, 5),
                    Price = 899.99M,
                    Weight = 7.2,
                    CategoryId = 5, // Loadcell Pedals
                    BrandId = 5,    // Heusinkveld
                    LocationId = 5, // Ruse
                    IsDeleted = false
                }
            );
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ProductCustomer> ProductsCustomers { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<BundleProduct> BundlesProducts { get; set; }
        public DbSet<ShopProductDiscount> ShopsProductsDiscounts { get; set; }
    }
}
