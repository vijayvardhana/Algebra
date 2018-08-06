using Newtonsoft.Json;
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
        public string AccountId { get; set; }

        [Required]
        public string ReferredBy { get; set; }

        [Required]
        public short MembershipType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ProfessionalTitle { get; set; }

        public string Designation { get; set; }

        public string Organization { get; set; }

        public string PresentAddress { get; set; }

        public string TelephoneNumber { get; set; }

        public string CorrespondenceAddress { get; set; }

        public string MobileNumber { get; set; }

        public string Location { get; set; }

        public string FormPath { get; set; }

        public string CreatedBy { get; set; }


        #endregion

        #region Lazy load Properties

        public virtual Spouse Spouse { get; set; }
        public virtual ICollection<Dependent> Dependents { get; set; }
        public virtual PaymentDetails Payment { get; set; }

        #endregion
    }
}
