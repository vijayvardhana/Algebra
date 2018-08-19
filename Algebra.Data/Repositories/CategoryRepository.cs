using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algebra.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork)
        {
            List<SelectListItem> types = unitOfWork.Categories.GetAll()
                .OrderBy(n => n.Id)
                    .Select(n => new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Type
                    }).ToList();

            var defaultType = new SelectListItem()
            {
                Value = null,
                Text = "--- Select membership type ---"
            };
            types.Insert(0, defaultType);
            return new SelectList(types, "Value", "Text");

        }
    }
}
