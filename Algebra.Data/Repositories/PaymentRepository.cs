using Algebra.Entities.Models;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public Payment GetPaymentByMemberId(int id)
        {
            return _dbContext
                 .Payments
                 .SingleOrDefault(p=>p.MemberId == id);
        }
    }
}
