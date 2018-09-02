using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Algebra.Entities.ViewModels;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;
using System;
using NToastNotify;
using System.Linq;
using Mapster;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Algebra.Web.Controllers
{
    //[Route("api/[controller]")]
    public class MemberController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ApplicationVariables _applicationVariables;
        private readonly IToastNotification _toastNotification;

        public MemberController(ApplicationDbContext dbContext, IOptions<ApplicationVariables> options, IToastNotification toastNotification)
        {
            _dbContext = dbContext;
            _applicationVariables = options.Value;
            _toastNotification = toastNotification;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<MemberViewModels> members;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                ViewBag.Categories = unitOfWork.Categories.GetDropDown(unitOfWork);
                ViewBag.Referrers = unitOfWork.Referrers.GetDropDown(unitOfWork);
                ViewBag.Locations = unitOfWork.Locations.GetDropDown(unitOfWork);
                members = unitOfWork
                    .Members
                    .GetAll()
                    .Adapt<IEnumerable<MemberViewModels>>();
            }
            return View(members);
        }

        [HttpGet]
        public IActionResult AddMember(int id)
        {
            RegistrationFormViewModel model;

            ViewBag.Title = (id > 0) ? "Edit" : "Add";
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                model = unitOfWork.Members.CreateMember(id);
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddMember(RegistrationFormViewModel m)
        {
            RegistrationFormViewModel model;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                if (m.IsNew == false)
                {
                    model = unitOfWork.Members.GetRegistrationViewModels(m.Id);
                    model.IsNew = m.IsNew;
                }
                else
                {
                    model = FillDropDowns(unitOfWork, m);
                    model = unitOfWork.Members.CreateRegistration(m);
                    model.CreatedBy = User.Identity.Name;
                    model.IsNew = false;
                }
            }
            return View("Registration", model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("api/member/post")]
        public IActionResult Post([FromBody] JObject model)
        {
            if (ModelState.IsValid)
            {
                JObject obj = JObject.Parse(model.ToString());
                string objValue = ((JProperty)obj.Last)
                    .Value["IsNew"]
                    .ToString()
                    .ToLower();
                bool isNew = Convert.ToBoolean(objValue);

                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    Member m = unitOfWork.Members.SetMemberEntities(model);
                    var member = unitOfWork.Members.GetMemberByAccountNumber(m.AccountId);
                    if (member != null)
                    {
                        return BadRequest($"The account number '{m.AccountId}' is already assign to some other user.");
                    }
                    m.CreatedBy = User.Identity.Name;
                    unitOfWork.Members.Add(m);
                    try
                    {
                        int successId = unitOfWork.Commit();
                        if (successId > 0)
                        {
                            //_toastNotification.AddSuccessToastMessage("SUCCESS : Member added successfully!");
                            return Ok("SUCCESS : Member added successfully!");
                        }

                    }
                    catch (Exception e)
                    {
                        return BadRequest($"Error : '{e.Message}'");
                        throw;
                    }
                }
            }
            else
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                // _toastNotification.AddWarningToastMessage("WARNING : model state is not valid!");
                return BadRequest($"WARNING : model state is not valid! {messages}");
            }
            return View(); ;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/member/get/{id}")]
        public IActionResult Get(int id)
        {
            RegistrationFormViewModel model;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                model = unitOfWork.Members.GetRegistrationViewModels(id);
            };
            return View("Details", model);
        }


        private RegistrationFormViewModel FillDropDowns(IUnitOfWork unitOfWork, RegistrationFormViewModel model)
        {
            model.Locations = unitOfWork.Locations.GetDropDown(unitOfWork);
            model.Categories = unitOfWork.Categories.GetDropDown(unitOfWork);
            model.Referrers = unitOfWork.Referrers.GetDropDown(unitOfWork);
            model.Modes = unitOfWork.Modes.GetDropDown(unitOfWork);
            return model;
        }
    }
}


//return members;
// Example1
//var course = unitOfWork.Courses.Get(1);

//// Example2
//var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

//// Example3
//var author = unitOfWork.Authors.GetAuthorWithCourses(1);
//unitOfWork.Courses.RemoveRange(author.Courses);
//unitOfWork.Authors.Remove(author);
//unitOfWork.Complete();