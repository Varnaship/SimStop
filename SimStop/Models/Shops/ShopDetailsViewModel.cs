namespace SimStop.Web.Models.Shop
{
    public class ShopDetailsViewModel
    {
        public int Id { get; set; }
        public string ShopName { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public decimal? TotalRevenue { get; set; }
        public bool IsOwner { get; set; }
    }
}


