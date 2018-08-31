using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using Algebra.Data;
using Algebra.Data.Repositories;
using System.Linq;
using Mapster;
using Algebra.Web.Toast;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private ApplicationDbContext _dbContext;
        public LocationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Location> location;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                location = unitOfWork.Locations.GetAll();
            }
            //TempData["msg"] = "Getting location records for you !";
            this.AddToastMessage("Info", "Getting location records for you !", ToastType.Info);
            return View(location);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Route("api/location/edit")]
        public IActionResult Edit(int id)
        {
            LocationViewModels model =null;
            try
            {
                model = _dbContext.Locations
               .Where(i => i.Id == id)
               .FirstOrDefault()
               .Adapt<LocationViewModels>();
            }
            catch (Exception)
            {
                this.AddToastMessage("Error", "Somthing went wrong, please try again ", ToastType.Error);
            }
            this.AddToastMessage("Info", "Getting location model for edit", ToastType.Info);

            return View("Edit", model);
        }

        // POST api/<controller>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/location/edit")]
        public IActionResult Edit(LocationViewModels model)
        {
            if (ModelState.IsValid)
            {
                var m = _dbContext.Locations
                .Where(i => i.Id == model.Id)
                .FirstOrDefault();

                if (m != null)
                {
                    m.Name = model.Name;
                    m.Address = model.Address;
                    m.PhoneNumber = model.PhoneNumber;
                }
                else
                {
                    m = model.Adapt<Location>();
                    m.Created = User.Identity.Name;
                    _dbContext.Locations.Add(m);
                }

                _dbContext.SaveChanges();
                this.AddToastMessage("Success", "Location saved successfully", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("Warning", "Somthing went wrong, please try again ", ToastType.Warning);
            }
            IEnumerable<Location> locationList = _dbContext.Locations.ToList();
            return View("Index", locationList);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Route("api/location/delete/")]
        public void Delete(int id)
        {
            var model = _dbContext
                            .Locations
                            .Where(i => i.Id == id)
                            .SingleOrDefault();
            if (model != null)
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    unitOfWork.Locations.Remove(model);
                    var i = unitOfWork.Commit();
                }
            }

        }
    }
}
