using Algebra.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class ReferrerRepository : Repository<Referrer>, IReferrerRepository
    {
        public ReferrerRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        Referrer IReferrerRepository.GetReferrerByCode(string code)
        {
            return _dbContext.Referrers.FirstOrDefault(c => c.Code == code);
        }
    }
}
