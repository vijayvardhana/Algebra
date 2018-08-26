using Algebra.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algebra.Data.Repositories
{
    public class DependentRepository : Repository<Dependent>, IDependentRepository
    {
        public DependentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Dependent> GetDependentsByMemberId(int memberId)
        {
            return _dbContext
                .Dependents
                .Where(i => i.MemberId == memberId)
                .ToList();
        }
    }
}
