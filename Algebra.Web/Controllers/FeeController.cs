using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class FeeController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        //private string _created = User.Identity.Name;

        public FeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<MembershipFee> list;

            using(var unitOfWork = new UnitOfWork(_dbContext))
            {
                list = unitOfWork.Fees.GetAll();
                ViewBag.Locations = unitOfWork.Locations.GetLocations();
            }
            return View(list);
        }

        [HttpGet("Add")]
        //[Route("api/fee/add")]
        public IActionResult Add(int id)
        {
            MembershipFeeViewModels model;
            ViewBag.Title = (id > 0) ? "Edit" : "Add";
            using(var unitOfWork = new UnitOfWork(_dbContext))
            {
                model = unitOfWork.Fees.Get(id).Adapt<MembershipFeeViewModels>();
                ViewData["Locations"] = new SelectList(unitOfWork.Locations.GetLocations(), "Key", "Value", 0);
            }
            return View(model);
        }

        [HttpPost("Add")]
        //[Route("api/fee/add")]
        [ValidateAntiForgeryToken]
        public IActionResult Add(MembershipFeeViewModels model)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    var fee = unitOfWork.Fees.Get(model.Id);
                    if(fee != null)
                    {
                        id = fee.Id;
                        model.Adapt(fee);
                        unitOfWork.Fees.Update(fee);
                        unitOfWork.Commit();
                    }
                    else
                    {
                        var newFee = model.Adapt<MembershipFee>();
                        newFee.Created = User.Identity.Name;
                        unitOfWork.Fees.Add(newFee);
                        id = unitOfWork.Commit();
                    }
                }
            }
            return RedirectToAction("Details", new {id });
        }


        // GET: api/<controller>
        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            MembershipFeeViewModels model;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                model = unitOfWork.Fees.Get(id).Adapt<MembershipFeeViewModels>();
                ViewBag.Location = unitOfWork.Locations.GetLocationByInitials(model.LocationInitials);
            }
            return View(model);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
