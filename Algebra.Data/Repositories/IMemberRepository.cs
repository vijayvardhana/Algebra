using Algebra.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Data.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        IEnumerable<Member> GetLatestMembers(int count);
    }
}
