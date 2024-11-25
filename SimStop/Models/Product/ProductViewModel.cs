using SimStop.Data.Models;
using static SimStop.Common.Constants.DatabaseConstants;

namespace SimStop.Web.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
    }
}
