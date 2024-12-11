using SimStop.Data.Models;
using System.ComponentModel.DataAnnotations;
using static SimStop.Common.Constants.DatabaseConstants;

namespace SimStop.Web.Models.Product
{
    public class ProductEditViewModel
    {
        [Required]
        public int Id { get; set; } // Added Id to identify the product

        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; } // Changed to DateTime

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<Category>? Categories { get; set; } // Populate from GetCategories()
    }
}

