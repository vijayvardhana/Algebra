using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using Algebra.Web.Toast;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class EventCategoryController : Controller
    {
        private ApplicationDbContext _dbContext;
        public EventCategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<EventCategory> categories;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                categories = unitOfWork.EventCategories.GetAll();
            }
            //TempData["msg"] = "Getting location records for you !";
            this.AddToastMessage("Info", "Getting Event Categories for you !", ToastType.Info);
            return View(categories);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Route("api/eventcategory/edit")]
        public IActionResult Edit(int id)
        {
            EventCategoryViewModels model = null;
            try
            {
                model = _dbContext.EventCategories
                                .Where(i => i.Id == id)
                                .FirstOrDefault()
                                .Adapt<EventCategoryViewModels>();
            }
            catch (Exception)
            {
                this.AddToastMessage("Error", "Somthing went wrong, please try again ", ToastType.Error);
            }
            this.AddToastMessage("Info", "Getting event category model for edit", ToastType.Info);

            return View("Edit", model);
        }

        // POST api/<controller>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/eventcategory/edit")]
        public IActionResult Edit(EventCategoryViewModels model)
        {
            if (ModelState.IsValid)
            {
                var m = _dbContext.EventCategories
                .Where(i => i.Id == model.Id)
                .FirstOrDefault();

                if (m != null)
                {
                    m.Name = model.Name;
                    m.Description = model.Description;
                    m.Image = model.Image;
                }
                else
                {
                    m = model.Adapt<EventCategory>();
                    m.Created = User.Identity.Name;
                    _dbContext.EventCategories.Add(m);
                }

                _dbContext.SaveChanges();
                this.AddToastMessage("Success", "Event category saved successfully", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("Warning", "Somthing went wrong, please try again ", ToastType.Warning);
            }
            IEnumerable<EventCategory> list = _dbContext.EventCategories.ToList();
            return View("Index", list);
        }
    }
}
