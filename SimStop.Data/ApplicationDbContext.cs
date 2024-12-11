using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimStop.Data.Models;
using System;

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
            modelBuilder.Entity<Shop>()
                 .Property(s => s.TotalRevenue)
                 .HasColumnType("decimal(18,2)");

            DataSeeder.SeedCategories(modelBuilder);
            DataSeeder.SeedBrands(modelBuilder);
            DataSeeder.SeedLocations(modelBuilder);
            DataSeeder.SeedProducts(modelBuilder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopCustomer> ShopsCustomers { get; set; }
        public DbSet<ShopProduct> ShopsProducts { get; set; }
    }
}


