using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Created { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [MaxLength(20)]
        public string IpAddress { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
