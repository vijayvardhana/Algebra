using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public class MarkAttendanceRepository : Repository<MarkAttendance>, IMarkAttendanceRepository
    {
        public MarkAttendanceRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        { }
    }
}
