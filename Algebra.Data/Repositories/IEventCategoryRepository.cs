using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface IEventCategoryRepository: IRepository<EventCategory>
    {
        IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork);
    }
}
