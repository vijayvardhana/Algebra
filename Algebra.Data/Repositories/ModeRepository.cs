using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Algebra.Data.Repositories
{
    public class ModeRepository : Repository<Mode>, IModeRepository
    {
        public ModeRepository(ApplicationDbContext dbContext)
            : base(dbContext) { }

        public IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork)
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

        public List<object> GetPaymentModeDataForColumnChart()
        {
            List<object> list = new List<object>();
            using (IUnitOfWork uow = new UnitOfWork(_dbContext))
            {
                _dbContext.Database.OpenConnection();
                DbCommand cmd = _dbContext.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "GetPaymentModeDataForColumnChart";
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new[] { reader["PaymentMode"], (int)reader["Total"] });
                    }
                }
            }
            return list;
        }
    }
}
