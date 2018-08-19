using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


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

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? S_DateOfBirth { get; set; }

        [Display(Name = "Title/Profession")]
        public string S_ProfessionalTitle { get; set; }

        [Display(Name = "Designation")]
        public string S_Designation { get; set; }

        [Display(Name = "Organization")]
        public string S_Organization { get; set; }

        [Display(Name = "Present Address")]
        public string S_PresentAddress { get; set; }

        [Display(Name = "Telephone Number")]
        public string S_TelephoneNumber { get; set; }

        [Display(Name = "Correspondence Address")]
        public string S_CorrespondenceAddress { get; set; }

        [Required]
        [Display(Name = "Primary Mobile Number")]
        public string S_PrimaryMobileNumber { get; set; }

        [Display(Name = "Secondary Mobile Number")]
        public string S_SecondaryMobileNumber { get; set; }

        [Display(Name = "Email")]
        public string S_Email { get; set; }

        //[Display(Name = "Location")]
        //public string S_Location { get; set; }

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
