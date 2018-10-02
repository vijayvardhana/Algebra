using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class SpeakerRepository : Repository<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork)
        {
            List<SelectListItem> speakers = unitOfWork.Speakers.GetAll()
               .OrderBy(n => n.Name)
                   .Select(n =>
                   new SelectListItem
                   {
                       Value = n.Name.Trim(),
                       Text = n.Name.Trim()
                   }).ToList();
            return new SelectList(speakers, "Value", "Text");
        }
    }
}
