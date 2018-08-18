using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class ReferrerRepository : Repository<Referrer>, IReferrerRepository
    {
        public ReferrerRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        Referrer IReferrerRepository.GetReferrerByCode(string code)
        {
            return _dbContext.Referrers.FirstOrDefault(c => c.Code == code);
        }

        IEnumerable<SelectListItem> IReferrerRepository.GetDropDown()
        {
            using(var unitOfWork = new UnitOfWork(_dbContext))
            {
                List<SelectListItem> referrers = unitOfWork.Referrers.GetAll()
                    .OrderBy(i => i.Id)
                    .Select(t =>
                    new SelectListItem {
                        Value = t.Id.ToString(),
                        Text = t.Name
                    }).ToList();

                var defaultReferrer = new SelectListItem() {
                    Value = null,
                    Text = "--- Select Referrer ---"
                };
                referrers.Insert(0, defaultReferrer);
                return new SelectList(referrers, "Value", "Text");
            }
        }
    }
}
