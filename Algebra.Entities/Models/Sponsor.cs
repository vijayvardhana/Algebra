using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.Models
{
    public class Sponsor : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string Logo { get; set; }
    }
}
