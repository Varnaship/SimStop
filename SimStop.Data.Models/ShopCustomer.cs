using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimStop.Data.Models
{
    [PrimaryKey(nameof(ProductId), nameof(CustomerId))]
    public class ShopCustomer
    {
        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Required]
        public string CustomerId { get; set; } = null!;

        [ForeignKey(nameof(CustomerId))]
        public IdentityUser Customer { get; set; } = null!;

        [Required]
        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;
    }
}

