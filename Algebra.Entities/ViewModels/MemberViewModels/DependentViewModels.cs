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
        public string D_Name { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [AgeRangeValidator(ErrorMessage = "Age must be between 18 - 30", MinAge = 16, MaxAge = 20)]
        public DateTime D_DateOfBirth { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string D_Email { get; set; }

        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.Text)]
        public string D_MobileNumber { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [DataType(DataType.Text)]
        public string D_CardId { get; set; }
    }
}
