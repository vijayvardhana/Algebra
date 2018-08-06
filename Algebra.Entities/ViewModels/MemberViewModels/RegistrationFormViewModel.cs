using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class RegistrationFormViewModel
    {
        public RegistrationFormViewModel()
        {
            this.Member = new MemberViewModels();
            this.Spouse  = new SpouseViewModels();
            //this.Dependent = new DependentViewModels();
        }

        public MemberViewModels Member { get; set; }

        public SpouseViewModels Spouse { get; set; }

        //public DependentViewModels Dependent { get; set; }

        //[Required]
        //[Display(Name = "Referred By")]
        //[DataType(DataType.Text)]
        //public string R_ReferredBy { get; set; }

        //[Required]
        //[Display(Name = "Category of Membership")]
        //public short R_MembershipType { get; set; }

        //[Display(Name = "Location")]
        //public string R_Location { get; set; }
    }
}
