using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        IEnumerable<SelectListItem> IReferrerRepository.GetDropDown(IUnitOfWork unitOfWork)
        {
            List<SelectListItem> referrers = unitOfWork.Referrers.GetAll()
               .OrderBy(n => n.Name)
                   .Select(n =>
                   new SelectListItem
                   {
                       Value = n.Id.ToString(),
                       Text = n.Name
                   }).ToList();
            var defaultReferrer = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Referrer ---"
            };
            referrers.Insert(0, defaultReferrer);
            return new SelectList(referrers, "Value", "Text");
        }

        public List<object> GetReferrerDataForPieChart()
        {
            List<object> list = new List<object>();
            using (IUnitOfWork uow = new UnitOfWork(_dbContext))
            {
                _dbContext.Database.OpenConnection();
                DbCommand cmd = _dbContext.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "GetReferrerDataForPieChart";
                cmd.CommandType = CommandType.StoredProcedure;
                
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new[] { reader["Name"], (int)reader["Total"] });
                    }
                }
            }
            return list;
        }
    }
}
