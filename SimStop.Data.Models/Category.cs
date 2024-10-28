using static SimStop.Common.Constants.DatabaseConstants;
using System.ComponentModel.DataAnnotations;

namespace SimStop.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string CategoryName { get; set; } = null!;
    }
}
