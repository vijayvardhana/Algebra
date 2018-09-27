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
    public class SpeakerController : Controller
    {
        private ApplicationDbContext _dbContext;
        public SpeakerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Speaker> speakers;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                speakers = unitOfWork.Speakers.GetAll();
            }
            this.AddToastMessage("Info", "Getting Speakers for you !", ToastType.Info);
            return View(speakers);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Route("api/speaker/add")]
        public IActionResult Add(int id)
        {
            SpeakerViewModels model = null;
            ViewBag.Title = (id > 0) ? "Edit" : "Add";
            try
            {
                using (var unitOfWork = new UnitOfWork(_dbContext))
                {
                    model = unitOfWork.Speakers.Get(id).Adapt<SpeakerViewModels>();
                }
            }
            catch (Exception)
            {
                this.AddToastMessage("Error", "Somthing went wrong, please try again ", ToastType.Error);
            }
            this.AddToastMessage("Info", "Getting speaker model for edit", ToastType.Info);

            return View("Add", model);
        }

        // POST api/<controller>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/speaker/add")]
        public IActionResult Add(SpeakerViewModels model)
        {
            IEnumerable<Speaker> list = null;
            if (ModelState.IsValid)
            {
                int id = 0;
                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    var speaker = unitOfWork.Speakers.Get(model.Id);
                    if (speaker != null)
                    {
                        model.Adapt(speaker);
                        unitOfWork.Speakers.Update(speaker);
                        unitOfWork.Commit();
                    }
                    else
                    {
                        var s = model.Adapt<Speaker>();
                        s.Created = User.Identity.Name;
                        unitOfWork.Speakers.Add(s);
                        id = unitOfWork.Commit();
                    }

                    list = unitOfWork.Speakers.GetAll().ToList();
                }
                this.AddToastMessage("Success", "Speaker saved successfully", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("Warning", "Somthing went wrong, please try again ", ToastType.Warning);
            }

            return View("Index", list);
        }

    }
}
