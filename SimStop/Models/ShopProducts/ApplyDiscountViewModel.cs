namespace SimStop.Web.Models.Product
{
    public class ApplyDiscountViewModel
    {
        public int ShopId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public double Discount { get; set; }
    }
}
