using System.ComponentModel.DataAnnotations;
using static SimStop.Common.Constants.DatabaseConstants;


namespace SimStop.Data.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BrandNameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(BrandDescriptionMaxLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime FoundedOn { get; set; }
    }
}
