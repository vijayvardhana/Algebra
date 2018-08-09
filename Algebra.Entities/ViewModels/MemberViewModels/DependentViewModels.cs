using System;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class DependentViewModels
    {
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string D_Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? D_DateOfBirth { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        public string D_Email { get; set; }

        [Display(Name = "Mobile Number")]
        [DataType(DataType.Text)]
        public string D_MobileNumber { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [DataType(DataType.Text)]
        public string D_CardId { get; set; }
    }
}
