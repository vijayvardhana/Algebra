
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class Category : EntityBase
    {
        [Required]
        [MaxLength(200)]
        public string Type { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }
    }
}
