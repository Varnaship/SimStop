using static SimStop.Common.Constants.DatabaseConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SimStop.Data.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ShopNameMaxLength)]
        public string ShopName { get; set; } = null!;

        [Required]
        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; } = null!;

        [Required]
        public decimal TotalRevenue { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public ICollection<ShopProduct> ShopProducts { get; set; } = new List<ShopProduct>();
    }
}
