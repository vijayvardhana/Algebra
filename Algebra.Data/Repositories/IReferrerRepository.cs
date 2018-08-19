using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface IReferrerRepository : IRepository<Referrer>
    {
        Referrer GetReferrerByCode(string code);
        IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork);
    }
}
