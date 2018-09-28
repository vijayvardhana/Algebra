using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberRepository Members { get; }
        ISpouseRepository Spouses { get; }
        IUserRepository Users { get; }
        ILocationRepository Locations { get; }
        IReferrerRepository Referrers { get; }
        IModeRepository Modes { get; }
        IFeeRepository Fees { get; }
        ICategoryRepository Categories { get; }
        IDependentRepository Dependents { get; }
        IPaymentRepository Payments { get; }
        IChequeRepository Cheques { get; }

        IEventCategoryRepository EventCategories { get; }
        ISpeakerRepository Speakers { get; }
        ISponsorRepository Sponsors { get; }

        IAttendeeRepository Attendees { get; }


        int Commit();
        void Rollback();
    }
}
