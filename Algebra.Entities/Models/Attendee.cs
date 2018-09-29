using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Algebra.Entities.Models
{
    public class Attendee : EntityBase
    {
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [MaxLength(200)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string MobileNumber { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [DefaultValue(false)]
        public bool HasGuest { get; set; }

        public int? AttenderntId { get; set; }

        [ForeignKey("AttenderntId")]
        public virtual Attendee Attender { get; set; }

        public virtual ICollection<Attendee> Guest { get; set; }

    }
}
