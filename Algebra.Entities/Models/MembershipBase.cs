using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class MembershipBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CardId { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime MembershipStartDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime MembershipEndDate { get; set; } = DateTime.Now.AddYears(1);

        [MaxLength(100)]
        public string ImagePath { get; set; }

        [DefaultValue(false)]
        public bool IsActive { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
