using Algebra.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Data.Repositories
{
    public interface IDependentRepository : IRepository<Dependent>
    {
        IList<Dependent> GetDependentsByMemberId(int memberId);
    }
}
