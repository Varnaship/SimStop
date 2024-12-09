namespace SimStop.Web.Models.Product
{
    public class ShopProductsViewModel
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; } = null!;
        public bool IsOwner { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}


