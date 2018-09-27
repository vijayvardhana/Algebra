using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public class EventCategoryRepository : Repository<EventCategory>, IEventCategoryRepository
    {
        public EventCategoryRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
