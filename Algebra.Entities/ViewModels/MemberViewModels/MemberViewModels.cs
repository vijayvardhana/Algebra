using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Algebra.Entities.Models;

namespace Algebra.Entities.ViewModels
{
    public class MemberViewModels
    {
        [Required(ErrorMessage = "Please enter Account Number")]
        [Display(Name = "Account Number")]
        [DataType(DataType.Text)]
        public string M_AccountId { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [DataType(DataType.Text)]
        public string M_CardId { get; set; }

        [Required]
        [Display(Name = "Referred By")]
        [DataType(DataType.Text)]
        public string M_ReferredBy { get; set; }

        [Required]
        [Display(Name = "Category of Membership")]
        public short M_MembershipType { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string M_Title { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string M_FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [DataType(DataType.Text)]
        public string M_MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string M_LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? M_DateOfBirth { get; set; }

        [Display(Name = "Title/Profession")]
        public string M_ProfessionalTitle { get; set; }

        [Display(Name = "Designation")]
        public string M_Designation { get; set; }

        [Display(Name = "Organization")]
        public string M_Organization { get; set; }

        [Display(Name = "Present Address")]
        public string M_PresentAddress { get; set; }

        [Display(Name = "Telephone Number")]
        public string M_TelephoneNumber { get; set; }

        [Display(Name = "Correspondence Address")]
        public string M_CorrespondenceAddress { get; set; }

        [Display(Name = "Mobile Number")]
        public string M_MobileNumber { get; set; }

        [Display(Name = "Email")]
        public string M_Email { get; set; }

        
        public string M_Location { get; set; }

        [Display(Name = "Location")]
        public short M_LocationId { get; set; }

        [Required]
        public DateTime M_CreatedDate { get; set; }

        [Required]
        public DateTime M_MembershipStartDate { get; set; }

        [Required]
        public DateTime M_MembershipEndDate { get; set; }

        public string M_ImagePath { get; set; }
        public string M_FormPath { get; set; }

        public string M_CreatedBy { get; set; }

        public bool M_IsActive { get; set; }

        public bool M_IsDeleted { get; set; }


        public Spouse Spouse { get; set; }

    }
}
