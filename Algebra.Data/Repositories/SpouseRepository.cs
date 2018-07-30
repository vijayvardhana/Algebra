using Algebra.Entities.Models;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class SpouseRepository : Repository<Spouse>, ISpouseRepository
    {
        public SpouseRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        Spouse ISpouseRepository.GetSpouseByMemberId(int id)
        {
           return _dbContext.Spouse.SingleOrDefault(s=>s.MemberId == id);
        }
    }
}
