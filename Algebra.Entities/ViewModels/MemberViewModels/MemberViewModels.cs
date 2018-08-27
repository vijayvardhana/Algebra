using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Algebra.Entities.Models;
using Algebra.Entities.CustomValidator;

namespace Algebra.Entities.ViewModels
{
    public class MemberViewModels
    {
        public int M_Id { get; set; }

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
        public short M_ReferredBy { get; set; }

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

        [Required]
        [TwentyOneYears(21)]
        //[ClassicMovie(1960)]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime M_DateOfBirth { get; set; }

        [Display(Name = "Title/Profession")]
        public string M_ProfessionalTitle { get; set; }

        [Display(Name = "Designation")]
        public string M_Designation { get; set; }

        [Display(Name = "Organization")]
        public string M_Organization { get; set; }

        [Display(Name = "Telephone Number")]
        public string M_TelephoneNumber { get; set; }

        [Display(Name = "Present / Correspondence Address")]
        public string M_PresentAddress { get; set; }

        [Display(Name = "City")]
        public string M_PresentCity { get; set; }

        [Display(Name = "State")]
        public string M_PresentState { get; set; }

        [Display(Name = "Pin")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid pin code.")]
        public string M_PresentPin { get; set; }

        [Display(Name = "Permanent Address")]
        public string M_PermanentAddress { get; set; }

        [Display(Name = "City")]
        public string M_PermanentCity { get; set; }

        [Display(Name = "State")]
        public string M_PermanentState { get; set; }

        [Display(Name = "Pin")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid pin code.")]
        public string M_PermanentPin { get; set; }

        [Display(Name = "Primary Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string M_PrimaryMobileNumber { get; set; }

        [Display(Name = "Secondary Mobile Number")]
        public string M_SecondaryMobileNumber { get; set; }

        [Display(Name = "Email")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DataType(DataType.EmailAddress)]
        public string M_Email { get; set; }

        [Display(Name = "Gender")]
        public string M_Gender { get; set; }

        [Display(Name = "Marital Status")]
        public string M_MaritalStatus { get; set; }

        [Display(Name = "Occupation")]
        public string M_Occupation { get; set; }

        [Display(Name = "How would you like to be addressed?")]
        public string M_Addressed { get; set; }

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
