using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        #endregion
        #region Lazy-Load Properties

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        #endregion
    }
}
