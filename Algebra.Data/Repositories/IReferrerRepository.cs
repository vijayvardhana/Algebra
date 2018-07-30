using Algebra.Entities.Models;

namespace Algebra.Data.Repositories
{
    public interface IReferrerRepository : IRepository<Referrer>
    {
        Referrer GetReferrerByCode(string code);
    }
}
