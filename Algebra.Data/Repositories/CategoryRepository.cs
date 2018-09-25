using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        public List<object> GetCategoriesForBarChart()
        {
            List<object> list = new List<object>();
            using (IUnitOfWork uow = new UnitOfWork(_dbContext))
            {
                _dbContext.Database.OpenConnection();
                DbCommand cmd = _dbContext.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "GetCategoriesForBarChart";
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new[] { reader["CategoryName"], (int)reader["Total"] });
                    }
                }
            }
            return list;
        }
    }
}
