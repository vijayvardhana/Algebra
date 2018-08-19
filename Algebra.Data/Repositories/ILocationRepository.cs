using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        Location GetLocationByCode(string lc);

        //Dictionary<int, string> GetLocations();

        IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork);

        IEnumerable<SelectListItem> GetLocationFeeDropDown(IUnitOfWork unitOfWork);
    }
}
