using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
   public class Dependent: MembershipBase
    {
        #region Constructor
        public Dependent() { }
        #endregion Constructor

        #region Properties

        [Required]
        public int MemberId { get; set; }

        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [MaxLength(200)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MobileNumber { get; set; }

        public DateTime DependentDOB { get; set; }        

        #endregion Properties

        // Navigation properties
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
}
