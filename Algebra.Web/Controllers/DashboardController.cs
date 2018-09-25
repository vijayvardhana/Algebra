using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algebra.Data;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Algebra.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public DashboardController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("referrer")]
        public JsonResult GetReferrer()
        {
            List<object> referrers = null;

            using(IUnitOfWork unitOfWork =new UnitOfWork(_dbContext))
            {
                referrers = unitOfWork.Referrers.GetReferrerDataForPieChart();
            }
            return Json(referrers);
        }

        [HttpGet]
        [Route("paymentmode")]
        public JsonResult GetPaymentModeCount()
        {
            List<object> mode = null;
            using(IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
            {
                mode = unitOfWork.Modes.GetPaymentModeDataForColumnChart();
            }
            return Json(mode);
        }

        [HttpGet]
        [Route("category")]
        public JsonResult GetCategoriesCount()
        {
            List<object> categories = null;
            using(IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
            {
                categories = unitOfWork.Categories.GetCategoriesForBarChart();
            }
            return Json(categories);
        }
    }

}
