using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class SponsorRepository : Repository<Sponsor>, ISponsorRepository
    {
        public SponsorRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork, string[] selectedValue =null)
        {
            List<SelectListItem> sponsors = unitOfWork.Sponsors.GetAll()
               .OrderBy(n => n.Name)
                   .Select(n =>
                   new SelectListItem
                   {
                       Value = n.Name.Trim(),
                       Text = n.Name.Trim()
                   }).ToList();
            return new MultiSelectList(sponsors, "Value", "Text", selectedValue);
        }
    }
}
