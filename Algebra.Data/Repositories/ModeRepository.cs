using System.Collections.Generic;
using System.Linq;
using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Algebra.Data.Repositories
{
    public class ModeRepository : Repository<Mode>, IModeRepository
    {
        public ModeRepository(ApplicationDbContext dbContext)
            : base(dbContext) { }

        IEnumerable<SelectListItem> IModeRepository.GetDropDown(IUnitOfWork unitOfWork)
        {
            List<SelectListItem> modes = unitOfWork.Modes.GetAll()
            .OrderBy(m => m.Id)
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Text
            }).ToList();
            var defaultMode = new SelectListItem()
            {
                Value = null,
                Text = "--- Select payment mode ---"
            };
            modes.Insert(0, defaultMode);
            return new SelectList(modes, "Value", "Text");
        }
    }
}
