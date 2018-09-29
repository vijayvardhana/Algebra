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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    //[Route("api/[controller]")]
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
                        //model = unitOfWork.Attendees.Get(id).Adapt<AttendeeViewModels>();
                        model = unitOfWork
                            .Attendees
                            .GetAttendeeWithGuest(id)
                            .Adapt<AttendeeViewModels>();

                        //if (model.HasGuest)
                        //{
                        //    IList<AttendeeViewModels> list = null;
                        //    var guest = unitOfWork.Attendees.GetGuest(model.Id);
                        //    foreach(var g in guest)
                        //    {
                        //        list.Add(g.Adapt<AttendeeViewModels>());
                        //    }
                        //    model.Guest = list;
                        //}
                    }
                    else
                    {
                        model.Guest.Add(new AttendeeViewModels());
                        model.Guest.Add(new AttendeeViewModels());
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
        //[ValidateAntiForgeryToken]
        [Route("api/attendee/add")]
        public IActionResult Add([FromBody] JObject model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is not valid!");
            }

            Attendee attendee = BuildModel(model);

            int id = 0;
            using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
            {
                var a = unitOfWork
                    .Attendees
                    .GetAttendeeByMobileNumber(attendee.MobileNumber);

                if (a != null)
                {
                    return BadRequest("Attendee already exist with this mobile number!");
                }

                try
                {
                    if (attendee.Id > 0)
                    {
                        attendee.UpdatedDate = DateTime.Now;
                        unitOfWork.Attendees.Update(attendee);
                        unitOfWork.Commit();
                        return Ok("Attendee updated successfully");
                    }
                    else
                    {
                        attendee.Created = User.Identity.Name;
                        unitOfWork.Attendees.Add(attendee);
                        id = unitOfWork.Commit();
                        return Ok("Attendee added successfully");
                    }
                }
                catch (Exception e)
                {
                    return BadRequest($"Something went wrong! {e.Message}");
                }

            }
        }

        [HttpGet]
        [Route("api/attendee/edit")]
        public IActionResult Edit(int id)
        {
            AttendeeViewModels model;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {               
                model = unitOfWork
                    .Attendees
                    .Get(id)
                    .Adapt<AttendeeViewModels>();

                ViewBag.Host = $"{model.FirstName} {model.LastName}";
                ViewBag.Guest = unitOfWork.Attendees.GuestOf(model.AttenderntId);
            }
            return View(model);
        }

        [HttpPost]
        [Route("api/attendee/edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AttendeeViewModels model)
        {
            if (ModelState.IsValid)
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    try
                    {
                        var attendee = unitOfWork.Attendees.Get(model.Id);
                        if (attendee != null)
                        {
                            model.Adapt(attendee);
                            unitOfWork.Attendees.Update(attendee);
                            unitOfWork.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        throw;// Toast.ToastMessage("");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        #region helper method
        private Attendee BuildModel(JObject model)
        {
            string[] str = Utils.UnWrapObjects(model, 'o');
            Attendee attendee = JsonConvert.DeserializeObject<Attendee>(str[0]);
            Attendee guest1 = JsonConvert.DeserializeObject<Attendee>(str[1]);
            Attendee guest2 = JsonConvert.DeserializeObject<Attendee>(str[2]);

            List<Attendee> guestList = new List<Attendee>();
            if (guest1 != null)
            {
                guestList.Add(guest1);
            }

            if (guest2 != null)
            {
                guestList.Add(guest2);
            }

            attendee.Guest = guestList;

            return attendee;
        }

        #endregion healper method
    }
}
