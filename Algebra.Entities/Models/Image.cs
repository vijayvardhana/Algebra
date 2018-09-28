using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.Models
{
    public class Image : EntityBase
    {
        [MaxLength(200)]
        public string Name { get; set; }

        public int Length { get; set; }

        [MaxLength(200)]
        public string ContentType { get; set; }

        [MaxLength(20)]
        public string AccountId { get; set; }

        [MaxLength(50)]
        public string For { get; set; }

        [MaxLength(200)]
        public string Path { get; set; }
    }
}
