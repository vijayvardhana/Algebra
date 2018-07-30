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
        public string AccountId { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [DataType(DataType.Text)]
        public string CardId { get; set; }

        [Required]
        [Display(Name = "Referred By")]
        [DataType(DataType.Text)]
        public string ReferredBy { get; set; }

        [Required]
        [Display(Name = "Category of Membership")]
        public short MembershipType { get; set; }

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

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Title/Profession")]
        public string ProfessionalTitle { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Correspondence Address")]
        public string CorrespondenceAddress { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime MembershipStartDate { get; set; }

        [Required]
        public DateTime MembershipEndDate { get; set; }

        public string ImagePath { get; set; }
        public string FormPath { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }


        public Spouse Spouse { get; set; }

    }
}
