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
            IEnumerable<Member> members;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                members = unitOfWork.Members.GetMembersWithSpouseAndDependents();
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
            RegistrationFormViewModel model = new RegistrationFormViewModel();
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                model = unitOfWork.Members.CreateRegistration(m);
                model.CreatedBy = User.Identity.Name;
            }
            //return View();
            return View("Registration", model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("api/member/post")]
        public IActionResult Post([FromBody] JObject model)
        {
            if (ModelState.IsValid)
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    Member m = unitOfWork.Members.SetMemberEntities(model);
                    m.CreatedBy = User.Identity.Name;
                    unitOfWork.Members.Add(m);
                    try
                    {
                        int successId = unitOfWork.Commit();
                        if (successId > 0)
                        {
                            _toastNotification.AddSuccessToastMessage("SUCCESS : Member added successfully!");
                            return RedirectToAction("Index");
                        }

                    }
                    catch (Exception e)
                    {
                        _toastNotification.AddErrorToastMessage($"Error! {e.Message}");
                        throw;
                    }
                }
            }
            else
            {
                _toastNotification.AddWarningToastMessage("WARNING : model state is not valid!");
            }
            return View("Index"); ;
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