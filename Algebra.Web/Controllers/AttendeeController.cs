using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using Algebra.Web.Toast;
using Mapster;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class AttendeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public AttendeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<Attendee> attendees = null;

            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                attendees = unitOfWork.Attendees.GetAll();
            }
            this.AddToastMessage("Info", "Getting list of attendee and guest for you !", ToastType.Info);
            return View(attendees);
        }

        [HttpGet("{id}")]
        [Route("api/attendee/add")]
        public IActionResult Add(int id)
        {
            AttendeeViewModels model = new AttendeeViewModels();
            ViewBag.Title = (id > 0) ? "Edit" : "Add";
            try
            {
                using (var unitOfWork = new UnitOfWork(_dbContext))
                {
                    if (id > 0)
                    {
                        model = unitOfWork.Attendees.Get(id).Adapt<AttendeeViewModels>();
                    }
                }
            }
            catch (Exception)
            {
                this.AddToastMessage("Error", "Somthing went wrong, please try again ", ToastType.Error);
            }
            this.AddToastMessage("Info", "Getting attendee form for edit", ToastType.Info);

            return View("Add", model);
        }

        // POST api/<controller>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/attendee/add")]
        public IActionResult Add(AttendeeViewModels model)
        {
            IEnumerable<Attendee> list = null;
            if (ModelState.IsValid)
            {
                int id = 0;
                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    var attendees = unitOfWork.Attendees.Get(model.Id);
                    if (attendees != null)
                    {
                        model.Adapt(attendees);
                        unitOfWork.Attendees.Update(attendees);
                        unitOfWork.Commit();
                    }
                    else
                    {
                        var a = model.Adapt<Attendee>();
                        a.Created = User.Identity.Name;
                        unitOfWork.Attendees.Add(a);
                        id = unitOfWork.Commit();
                    }

                    list = unitOfWork.Attendees.GetAll().ToList();
                }
                this.AddToastMessage("Success", "Attendee saved successfully", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("Warning", "Somthing went wrong, please try again ", ToastType.Warning);
            }

            return View("Index", list);
        }

    }
}
