using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface ISpeakerRepository : IRepository<Speaker>
    {
        IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork);
    }
}
