using static SimStop.Common.Constants.DatabaseConstants;
using System.ComponentModel.DataAnnotations;

namespace SimStop.Data.Models
{
    public class Bundle
    {
        [Key]
        public int BundleId { get; set; }
        [Required]
        [MaxLength(BundleNameMaxLength)]
        public string Name { get; set; }
        [Required]
        public double Discount { get; set; }
        public ICollection<Product> Products = new List<Product>();
    }
}
