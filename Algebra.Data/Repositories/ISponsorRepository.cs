using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface ISponsorRepository : IRepository<Sponsor>
    {
        IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork, string[] selectedValue);
    }
}
