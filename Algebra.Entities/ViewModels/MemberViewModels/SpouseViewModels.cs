using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Algebra.Entities.CustomValidator;

namespace Algebra.Entities.ViewModels
{
    public class SpouseViewModels
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [DataType(DataType.Text)]
        public string S_CardId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string S_Title { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string S_FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [DataType(DataType.Text)]
        public string S_MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string S_LastName { get; set; }

        [Required]
        [TwentyOneYears(21)]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime S_DateOfBirth { get; set; }

        [Display(Name = "Title/Profession")]
        public string S_ProfessionalTitle { get; set; }

        [Display(Name = "Designation")]
        public string S_Designation { get; set; }

        [Display(Name = "Organization")]
        public string S_Organization { get; set; }

        [Display(Name = "Telephone Number")]
        public string S_TelephoneNumber { get; set; }

        [Display(Name = "Present / Correspondence Address")]
        public string S_PresentAddress { get; set; }

        [Display(Name = "City")]
        public string S_PresentCity { get; set; }

        [Display(Name = "State")]
        public string S_PresentState { get; set; }

        [Display(Name = "Pin")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid pin code.")]
        public string S_PresentPin { get; set; }

        [Display(Name = "Permanent Address")]
        public string S_PermanentAddress { get; set; }

        [Display(Name = "City")]
        public string S_PermanentCity { get; set; }

        [Display(Name = "State")]
        public string S_PermanentState { get; set; }

        [Display(Name = "Pin")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid pin code.")]
        public string S_PermanentPin { get; set; }

        [Display(Name = "Primary Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string S_PrimaryMobileNumber { get; set; }

        [Display(Name = "Secondary Mobile Number")]
        public string S_SecondaryMobileNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string S_Email { get; set; }

        [Display(Name = "Gender")]
        public string S_Gender { get; set; }

        [Display(Name = "Marital Status")]
        public string S_MaritalStatus { get; set; }

        [Display(Name = "Occupation")]
        public string S_Occupation { get; set; }

        [Display(Name = "How would you like to be addressed?")]
        public string Addressed { get; set; }

        [Required]
        public DateTime S_CreatedDate { get; set; }

        [Required]
        public DateTime S_MembershipStartDate { get; set; }

        [Required]
        public DateTime S_MembershipEndDate { get; set; }

        public string S_ImagePath { get; set; }

        public string S_CreatedBy { get; set; }

        public bool S_IsActive { get; set; }

        public bool S_IsDeleted { get; set; }
    }
}
