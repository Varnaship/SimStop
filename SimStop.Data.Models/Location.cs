using static SimStop.Common.Constants.DatabaseConstants;
using System.ComponentModel.DataAnnotations;

namespace SimStop.Data.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(LocationNameMaxLenght)]
        public string LocationName { get; set; } = null!;
    }
}
