using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public class AttendeeRepository : Repository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
