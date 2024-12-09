namespace SimStop.Web.Models.Shop
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        public string ShopName { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public bool IsOwner { get; set; }
    }
}


