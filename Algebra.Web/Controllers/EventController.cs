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
using Microsoft.EntityFrameworkCore.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private ApplicationDbContext _dbContext;
        public EventController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Event> events = null;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                events = unitOfWork.Events.GetAll();
            }
            this.AddToastMessage("Info", "Getting Events for you !", ToastType.Info);
            return View(events);
        }

        // GET api/<controller>/5
        [HttpGet("add")]
        //[Route("api/event/add")]
        public IActionResult Add(int id)
        {
            EventViewModels model = new EventViewModels();
            ViewBag.Title = (id > 0) ? "Edit" : "Add";
            try
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    var m = unitOfWork.Events.Get(id);
                    if (m != null)
                    {
                        model.Title = m.Title;
                        model.Description = m.Description;
                        model.StartDate = m.StartDate;
                        model.Region = m.Region;
                        model.Format = m.Format;
                        model.Categories = m.Categories.Split(",");
                        model.Speakers = m.Speakers.Split(",");
                        model.Sponsors = m.Sponsors.Split(",");
                        model.Address = m.Address;
                        model.City = m.City;
                        model.State = m.State;

                       // model = m.Adapt<EventViewModels>();
                    }
                    model.CategoryList = unitOfWork.EventCategories.GetDropDown(unitOfWork);
                    model.SpeakerList = unitOfWork.Speakers.GetDropDown(unitOfWork);
                    model.SponsorList = unitOfWork.Sponsors.GetDropDown(unitOfWork, model.Sponsors);
                }
            }
            catch (Exception)
            {
                this.AddToastMessage("Error", "Somthing went wrong, please try again ", ToastType.Error);
            }
            this.AddToastMessage("Info", "Getting speaker model for edit", ToastType.Info);

            return View("Add", model);
        }

        [HttpPost("add")]
        //[Route("api/event/add")]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EventViewModels model)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    var evt = unitOfWork.Events.Get(model.Id);
                    if (evt != null)
                    {
                        id = evt.Id;
                        model.Adapt(evt);
                        evt.Categories = model.Categories.Join(",");
                        evt.Sponsors = model.Sponsors.Join(",");
                        evt.Speakers = model.Speakers.Join(",");
                        evt.UpdatedDate = DateTime.Now;
                        unitOfWork.Events.Update(evt);
                        unitOfWork.Commit();
                        this.AddToastMessage("Info", "Event updated successfully", ToastType.Info);
                    }
                    else
                    {
                        var newEvent = model.Adapt<Event>();
                        newEvent.Created = User.Identity.Name;
                        newEvent.Categories = model.Categories.Join(",");
                        newEvent.Sponsors = model.Sponsors.Join(",");
                        newEvent.Speakers = model.Speakers.Join(",");
                        unitOfWork.Events.Add(newEvent);
                        id = unitOfWork.Commit();
                        this.AddToastMessage("Info", "Event added successfully", ToastType.Info);
                    }
                }
            }
            else
            {
                this.AddToastMessage("Error", "Model state is not valid", ToastType.Info);
            }
            return View("Details", model);
        }

        [HttpGet("details")]
        public IActionResult Details(EventViewModels model)
        {
            return View(model);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            EventViewModels model = new EventViewModels();
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                var m = unitOfWork.Events.Get(id);
                if (m != null)
                {
                    model.Title = m.Title;
                    model.Description = m.Description;
                    model.StartDate = m.StartDate;
                    model.Region = m.Region;
                    model.Format = m.Format;
                    model.Categories = m.Categories.Split(",");
                    model.Speakers = m.Speakers.Split(",");
                    model.Sponsors = m.Sponsors.Split(",");
                    model.Address = m.Address;
                    model.City = m.City;
                    model.State = m.State;
                }
            }
            return View("Details", model);
        }
    }
}
