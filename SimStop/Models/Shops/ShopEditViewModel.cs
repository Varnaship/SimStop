using SimStop.Data.Models;
using System.ComponentModel.DataAnnotations;
using static SimStop.Common.Constants.DatabaseConstants;

namespace SimStop.Web.Models.Shop
{
    public class ShopEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ShopNameMaxLength)]
        public string ShopName { get; set; } = null!;

        [Required]
        public int LocationId { get; set; }

        public List<Location> Locations { get; set; } = new List<Location>();

        [Required]
        public decimal TotalRevenue { get; set; }
    }
}
