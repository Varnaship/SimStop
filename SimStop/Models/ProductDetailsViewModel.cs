using SimStop.Data.Models;
using static SimStop.Common.Constants.DatabaseConstants;
namespace SimStop.Web.Models
{
    public class ProductDetailsViewModel
    {
        public required int Id { get; set; }

        public required string Name { get; set; }
        public required string Description { get; set; } 
        public required string ReleaseDate { get; set; } = DateTime.Today.ToString(ProductReleaseDateFormat);

        public required decimal Price { get; set; }

        public required double Weight { get; set; }

        public required int CategoryId { get; set; }

        public required int BrandId { get; set; }

        public required Brand Brand { get; set; } = null!;

        public required int LocationId { get; set; }

        public required Location Location { get; set; } = null!;
        public bool HasBought { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
