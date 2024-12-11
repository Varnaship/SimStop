namespace SimStop.Web.Models.Product
{
    public class ProductIndexViewModel
    {
        public List<ProductViewModel>? Products { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
