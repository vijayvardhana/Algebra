using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        Location GetLocationByInitials(char c);
    }
}
