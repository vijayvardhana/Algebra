using System.Collections.Generic;

namespace Algebra.Entities.ViewModels
{
    public class RegistrationFormViewModel
    {
        public RegistrationFormViewModel()
        {
            this.Member = new MemberViewModels();
            this.Spouse  = new SpouseViewModels();
            this.Dependent = new List<DependentViewModels>();
            this.Payment = new PaymentViewModel();

        }

        public MemberViewModels Member { get; set; }

        public SpouseViewModels Spouse { get; set; }

        public IList<DependentViewModels> Dependent { get; set; }

        public PaymentViewModel Payment { get; set; }

    }
}
