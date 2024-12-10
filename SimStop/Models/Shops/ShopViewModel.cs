namespace SimStop.Web.Models.Shop
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        public string ShopName { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public decimal Price { get; set; } // Add Price property
        public bool IsOwner { get; set; }
    }
}