using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.Models
{
    public class Location : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public char Initials { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

    }
}
