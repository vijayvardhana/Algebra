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
        IPaymentModeRepository PaymentModes { get; }
        IMembershipFeeRepository Fees { get; }
        
        int Commit();
        void Rollback();
    }
}
