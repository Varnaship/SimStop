using SimStop.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace SimStop.Web.Models
{
    public class ProductEditViewModel
    {
        [Required]
        public int Id { get; set; } // Added Id to identify the product

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Release Date")]
        public string AddedOn { get; set; } = null!; // Must match the format "d MMM yyyy"

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<Category>? Categories { get; set; } // Populate from GetCategories()
    }
}
