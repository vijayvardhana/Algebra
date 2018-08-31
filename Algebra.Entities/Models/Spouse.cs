using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class Spouse:MembershipBase
    {

        #region Constructor
        public Spouse() { }
        #endregion Constructor

        #region Properties

        [Required]
        public int MemberId { get; set; }

        [Required]
        public short Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string PrimaryMobileNumber { get; set; }

        [MaxLength(50)]
        public string SecondaryMobileNumber { get; set; }

        [MaxLength(50)]
        public string TelephoneNumber { get; set; }

        [MaxLength(50)]
        public string ProfessionalTitle { get; set; }

        [MaxLength(100)]
        public string Designation { get; set; }

        [MaxLength(100)]
        public string Organization { get; set; }

        [MaxLength(200)]
        public string PresentAddress { get; set; }

        [MaxLength(100)]
        public string PresentCity { get; set; }

        [MaxLength(100)]
        public string PresentState { get; set; }

        [MaxLength(10)]
        public string PresentPin { get; set; }

        [MaxLength(500)]
        public string PermanentAddress { get; set; }

        [MaxLength(100)]
        public string PermanentCity { get; set; }

        [MaxLength(100)]
        public string PermanentState { get; set; }

        [MaxLength(10)]
        public string PermanentPin { get; set; }

        public short Gender { get; set; }

        public short MaritalStatus { get; set; }

        public short Occupation { get; set; }

        public int SponcerId { get; set; }

        [MaxLength(100)]
        public string Addressed { get; set; }

        public DateTime SpouseDOB { get; set; }

        #endregion
        #region Lazy-Load Properties

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        #endregion
    }
}
