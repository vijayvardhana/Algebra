using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public class PaymentModeRepository : Repository<PaymentMode>, IPaymentModeRepository
    {
        public PaymentModeRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        { }
    }
}
