using SimStop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SimStop.Common.Constants.DatabaseConstants;

namespace SimStop.Web.Models.Product
{
    public class ProductCreateViewModel
    {
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Weight must be greater than 0.")]
        public double Weight { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<Category>? Categories { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public IEnumerable<Brand>? Brands { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public IEnumerable<Location>? Locations { get; set; }
    }
}
