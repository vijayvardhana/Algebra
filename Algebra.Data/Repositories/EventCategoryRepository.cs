using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class EventCategoryRepository : Repository<EventCategory>, IEventCategoryRepository
    {
        public EventCategoryRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork)
        {
            List<SelectListItem> categories = unitOfWork.EventCategories.GetAll()
               .OrderBy(n => n.Name)
                   .Select(n =>
                   new SelectListItem
                   {
                       Value = n.Name.Trim(),
                       Text = n.Name.Trim()
                   }).ToList();
            return new SelectList(categories, "Value", "Text");
        }
    }
}
