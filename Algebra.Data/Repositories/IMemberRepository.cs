using Algebra.Entities.Models;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        IEnumerable<Member> GetLatestMembers(int count);

        int GetMaxId(int _initialAccountNumber);

        IEnumerable<Member> GetMembersWithSpouseAndDependents();
    }
}
