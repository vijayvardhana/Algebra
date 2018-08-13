using Algebra.Entities.Models;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        Location GetLocationByInitials(char c);

        Dictionary<int, string> GetLocations();
    }
}
