namespace SimStop.Web.Models.Product
{
    public class AddProductViewModel
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; } = null!;
        public int ProductId { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
