using System.Collections.Generic;
using Algebra.Entities.Models;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public IEnumerable<Member> GetLatestMembers(int count)
        {
            return _dbContext.Members.ToList();
                //.OrderBy(m => m.CreatedDate)
                //.Take(count)
                //.ToList();
        }
    }
}
