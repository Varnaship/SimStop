using static SimStop.Common.Constants.DatabaseConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
