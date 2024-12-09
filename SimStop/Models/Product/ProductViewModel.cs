namespace SimStop.Web.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string Description { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
    }
}
