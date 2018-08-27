using Algebra.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class ChequeRepository : Repository<Cheque>, IChequeRepository
    {
        public ChequeRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public List<Cheque> GetChequesByPaymentId(int id)
        {
            return _dbContext
                .Cheques
                .Where(c => c.PaymentId == id)
                .ToList();
        }
    }
}
