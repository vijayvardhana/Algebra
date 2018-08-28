using Algebra.Entities.CustomValidator;
using System;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class DependentViewModels
    {
        [Required]
        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [AgeRangeValidator(ErrorMessage = "Age must be between 18 - 30", MinAge = 16, MaxAge = 20)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.Text)]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [DataType(DataType.Text)]
        public string CardId { get; set; }

        [Required]
        [Display(Name = "Membership Start Date")]
        public DateTime MembershipStartDate { get; set; }

        [Required]
        [Display(Name = "Membership End Date")]
        public DateTime MembershipEndDate { get; set; }
    }
}
