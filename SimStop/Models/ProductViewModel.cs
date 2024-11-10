using SimStop.Data.Models;
using static SimStop.Common.Constants.DatabaseConstants;

namespace SimStop.Web.Models
{
    public class ProductViewModel
    {
        public required int Id { get; set; }

        public required string Name { get; set; } = null!;

        public required string Description { get; set; } = null!;

        public required string ReleaseDate { get; set; } = DateTime.Today.ToString(ProductReleaseDateFormat);

        public required decimal Price { get; set; }

        public required int BrandId { get; set; }

    }
}
