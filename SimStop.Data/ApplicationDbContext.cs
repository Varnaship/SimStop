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
            new Category { Id = 1,CategoryName = "Wheel" },
            new Category { Id = 2,CategoryName = "Handbrake" },
            new Category { Id = 3,CategoryName = "Wheel Base" },
            new Category { Id = 4,CategoryName = "Pedals" },
            new Category { Id = 5,CategoryName = "Loadcell Pedals" },
            new Category { Id = 6,CategoryName = "Direct-Drive Wheel Base" },
            new Category { Id = 7,CategoryName = "Sequential Shifter" },
            new Category { Id = 8,CategoryName = "H-Patern Shifter" });
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
