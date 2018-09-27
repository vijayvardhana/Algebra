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
    public class SponsorController : Controller
    {
        private ApplicationDbContext _dbContext;
        public SponsorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Sponsor> sponsors;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                sponsors = unitOfWork.Sponsors.GetAll();
            }
            //TempData["msg"] = "Getting location records for you !";
            this.AddToastMessage("Info", "Getting Sponsors for you !", ToastType.Info);
            return View(sponsors);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Route("api/sponsor/add")]
        public IActionResult Add(int id)
        {
            SponsorViewModels model = null;
            ViewBag.Title = (id > 0) ? "Edit" : "Add";
            try
            {
                using (var unitOfWork = new UnitOfWork(_dbContext))
                {
                    model = unitOfWork.Sponsors.Get(id).Adapt<SponsorViewModels>();
                }
            }
            catch (Exception)
            {
                this.AddToastMessage("Error", "Somthing went wrong, please try again ", ToastType.Error);
            }
            this.AddToastMessage("Info", "Getting event category model for edit", ToastType.Info);

            return View("Add", model);
        }

        // POST api/<controller>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/sponsor/add")]
        public IActionResult Add(SponsorViewModels model)
        {
            IEnumerable<Sponsor> list = null;
            if (ModelState.IsValid)
            {
                int id = 0;
                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    var sponsor = unitOfWork.Sponsors.Get(model.Id);
                    if (sponsor != null)
                    {
                        model.Adapt(sponsor);
                        unitOfWork.Sponsors.Update(sponsor);
                        unitOfWork.Commit();
                    }
                    else
                    {
                        var s = model.Adapt<Sponsor>();
                        s.Created = User.Identity.Name;
                        unitOfWork.Sponsors.Add(s);
                        id = unitOfWork.Commit();
                    }

                    list = unitOfWork.Sponsors.GetAll().ToList();
                }
                this.AddToastMessage("Success", "Sponsor saved successfully", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("Warning", "Somthing went wrong, please try again ", ToastType.Warning);
            }

            return View("Index", list);
        }
    }
}
