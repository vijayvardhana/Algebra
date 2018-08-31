using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.Models
{
    public class Member : MembershipBase
    {

        #region Constructor
        public Member() { }
        #endregion

        #region Properties

        [Required]
        [MaxLength(50)]
        public string AccountId { get; set; }

        [Required]
        public short ReferredBy { get; set; }

        [Required]
        public short MembershipType { get; set; }

        [Required]
        public short Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [MaxLength(200)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string ProfessionalTitle { get; set; }

        [MaxLength(100)]
        public string Designation { get; set; }

        [MaxLength(200)]
        public string Organization { get; set; }

        [MaxLength(50)]
        public string TelephoneNumber { get; set; }

        [MaxLength(500)]
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

        [Required]
        [MaxLength(50)]
        public string PrimaryMobileNumber { get; set; }

        [MaxLength(50)]
        public string SecondaryMobileNumber { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }

        [Required]
        public short LocationId { get; set; }

        [MaxLength(255)]
        public string FormPath { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public short Gender { get; set; }

        public short MaritalStatus { get; set; }

        public short Occupation { get; set; }

        public int SponcerId { get; set; }

        [MaxLength(100)]
        public string Addressed { get; set; }

        public DateTime MemberDOB { get; set; }

        #endregion

        #region Lazy load Properties

        public virtual Spouse Spouse { get; set; }
        public virtual ICollection<Dependent> Dependents { get; set; }
        public virtual Payment Payments { get; set; }

        #endregion
    }
}
