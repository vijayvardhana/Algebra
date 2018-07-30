using Algebra.Entities.Models;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        Location ILocationRepository.GetLocationByInitials(char c)
        {
            return _dbContext.Locations.FirstOrDefault(i => i.Initials == c);
        }
    }
}
