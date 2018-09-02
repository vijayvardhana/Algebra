using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class RegistrationFormViewModel
    {
        public RegistrationFormViewModel()
        {
            Member = new MemberViewModels();
            Spouse  = new SpouseViewModels();
            Dependent = new List<DependentViewModels>();
            Payment = new PaymentViewModel();

        }
        public int Id { get; set; }

        public bool IsNew { get; set; }

        public MemberViewModels Member { get; set; }

        public SpouseViewModels Spouse { get; set; }

        public IList<DependentViewModels> Dependent { get; set; }

        public PaymentViewModel Payment { get; set; }

        [Required]
        [Display(Name = "Location")]
        public short LocationId { get; set; }

        public IEnumerable<SelectListItem> Locations { get; set; }

        [Required]
        [Display(Name = "Category of Membership")]
        public short MembershipType { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required]
        [Display(Name = "Referred By")]
        public short ReferredBy { get; set; }

        public IEnumerable<SelectListItem> Referrers { get; set; }

        public string CreatedBy { get; set; }

        public IEnumerable<SelectListItem> Modes { get; set; }
    }
}
