using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public interface ISpouseRepository : IRepository<Spouse>
    {
        Spouse GetSpouseByMemberId(int id);
    }
}
