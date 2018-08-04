﻿using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class RegistrationFormViewModel
    {
        public RegistrationFormViewModel()
        {
            this.Member = new MemberViewModels();
            //this.Spouse  = new SpouseViewModels();
            //this.Dependent = new DependentViewModels();
        }

        public MemberViewModels Member { get; set; }

        //public SpouseViewModels Spouse { get; set; }

        //public DependentViewModels Dependent { get; set; }

        [Required]
        [Display(Name = "Referred By")]
        [DataType(DataType.Text)]
        public string ReferredBy { get; set; }

        [Required]
        [Display(Name = "Category of Membership")]
        public short MembershipType { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
