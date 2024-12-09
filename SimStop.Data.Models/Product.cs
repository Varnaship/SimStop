using SimStop.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SimStop.Common.Constants.DatabaseConstants;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ProductNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(ProductDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public double Weight { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    [Required]
    public int BrandId { get; set; }

    [ForeignKey(nameof(BrandId))]
    public Brand Brand { get; set; } = null!;

    [Required]
    public int LocationId { get; set; }

    [ForeignKey(nameof(LocationId))]
    public Location Location { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public IList<ShopCustomer> ProductsClients { get; set; } = new List<ShopCustomer>();

    public ICollection<ShopProduct> ShopProducts { get; set; } = new List<ShopProduct>(); // Update reference
}


