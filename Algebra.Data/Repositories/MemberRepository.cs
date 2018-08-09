using System.Collections.Generic;
using Algebra.Entities.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Algebra.Data.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Member> GetLatestMembers(int count)
        {
            return _dbContext.Members//.ToList();
                .OrderBy(m => m.CreatedDate)
                .Take(count)
                .ToList();
        }

        public int GetMaxId(int _initialAccountNumber)
        {
            if (_dbContext.Members.Any())
            {
                return _dbContext.Members.Max(i => i.Id);
            }
            else
            {
                return _initialAccountNumber;
            }

        }

        public IEnumerable<Member> GetMembersWithSpouseAndDependents()
        {
            return _dbContext.Members
                .Include(i => i.Spouse)
                .Include(i => i.Dependents)
                .ToList();
        }
    }
}
