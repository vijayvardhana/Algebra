using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public class SponsorRepository : Repository<Sponsor>, ISponsorRepository
    {
        public SponsorRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
