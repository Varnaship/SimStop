using SimStop.Web.Models.Shop;
using System.Collections.Generic;

namespace SimStop.Web.Models.Product
{
    public class ProductShopsViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public List<ShopViewModel> Shops { get; set; } = new List<ShopViewModel>();
    }
}
