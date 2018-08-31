using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        Location GetLocationByCode(string lc);

        string GetLocationById(int id);

        string GetCodeDigitByLocationId(int id);

        IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork);

        IEnumerable<SelectListItem> GetLocationFeeDropDown(IUnitOfWork unitOfWork);
    }
}
