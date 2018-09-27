using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public class SpeakerRepository : Repository<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
