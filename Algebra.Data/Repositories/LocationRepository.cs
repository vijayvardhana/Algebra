using Algebra.Entities.Models;
using System.Collections.Generic;
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

        Dictionary<int, string> ILocationRepository.GetLocations()
        {
            Dictionary<int, string> loc = new Dictionary<int, string>();
            var locations = _dbContext.Locations;
            if (locations.Any())
            {
                foreach (var location in _dbContext.Locations)
                {
                    loc.Add(location.Id, location.Name);
                }
            }
            return loc;
        }
    }
}
