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
        public string CardId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [DataType(DataType.Text)]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [TwentyOneYears(21)]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Title/Profession")]
        public string ProfessionalTitle { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Present / Correspondence Address")]
        public string PresentAddress { get; set; }

        [Display(Name = "City")]
        public string PresentCity { get; set; }

        [Display(Name = "State")]
        public string PresentState { get; set; }

        [Display(Name = "Pin")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid pin code.")]
        public string PresentPin { get; set; }

        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        [Display(Name = "City")]
        public string PermanentCity { get; set; }

        [Display(Name = "State")]
        public string PermanentState { get; set; }

        [Display(Name = "Pin")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid pin code.")]
        public string PermanentPin { get; set; }

        [Display(Name = "Primary Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PrimaryMobileNumber { get; set; }

        [Display(Name = "Secondary Mobile Number")]
        public string SecondaryMobileNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Display(Name = "How would you like to be addressed?")]
        public string Addressed { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Display(Name = "Membership Start Date")]
        public DateTime MembershipStartDate { get; set; }

        [Required]
        [Display(Name = "Membership End Date")]
        public DateTime MembershipEndDate { get; set; }

        public string ImagePath { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
