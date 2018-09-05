﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Algebra.Entities.Models;
using Algebra.Entities.CustomValidator;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Algebra.Entities.ViewModels
{
    public class MemberViewModels
    {
        public int Id { get; set; }

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
        public short ReferredBy { get; set; }

        public IEnumerable<SelectListItem> Referrers { get; set; }

        [Required]
        [Display(Name = "Category of Membership")]
        public short MembershipType { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required]
        [Display(Name = "Title")]
        public short Title { get; set; }

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
        [ValidateAge(21, 65)]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? MemberDOB { get; set; }


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
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Gender")]
        public short Gender { get; set; }

        [Display(Name = "Marital Status")]
        public short MaritalStatus { get; set; }

        [Display(Name = "Occupation")]
        public short Occupation { get; set; }

        [Display(Name = "How would you like to be addressed?")]
        public string Addressed { get; set; }

        public string Location { get; set; }

        [Display(Name = "Location")]
        public short LocationId { get; set; }

        public IEnumerable<SelectListItem> Locations { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Display(Name = "Membership Start Date")]
        public DateTime MembershipStartDate { get; set; }

        [Required]
        [Display(Name = "Membership End Date")]
        public DateTime MembershipEndDate { get; set; }

        public string ImagePath { get; set; }
        public string FormPath { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsNew { get; set; }

        public Spouse Spouse { get; set; }

    }
}
