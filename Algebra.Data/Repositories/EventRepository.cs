using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
