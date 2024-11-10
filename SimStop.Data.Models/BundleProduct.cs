using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimStop.Data.Models
{
    [PrimaryKey(nameof(BundleId),nameof(ProductId))]
    public class BundleProduct
    {
        [Required]
        public int BundleId { get; set; }

        [ForeignKey(nameof(BundleId))]
        public Bundle Bundle { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}