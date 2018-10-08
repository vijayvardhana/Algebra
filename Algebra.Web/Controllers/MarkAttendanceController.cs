using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using Algebra.Web.Toast;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class MarkAttendanceController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public MarkAttendanceController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Index")]
        public IActionResult Index(int eventId=0)
        {
            MarkAttendanceViewModels attendance = new MarkAttendanceViewModels();

            using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
            {
                var e = unitOfWork.Events.Get(eventId);
                if (e != null)
                {
                    attendance.Event = e;
                }
            }
            this.AddToastMessage("Info", "Getting attendance form for you !", ToastType.Info);
            return View(attendance);
        }
    }
}
