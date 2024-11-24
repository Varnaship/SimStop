using SimStop.Data.Models;
using static SimStop.Common.Constants.DatabaseConstants;
namespace SimStop.Web.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public double Weight { get; set; }
    }
}
