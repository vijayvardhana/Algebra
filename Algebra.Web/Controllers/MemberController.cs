﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Algebra.Entities.ViewModels;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;

namespace Algebra.Web.Controllers
{
    //[Route("api/[controller]")]
    public class MemberController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ApplicationVariables _applicationVariables;

        public MemberController(ApplicationDbContext dbContext, IOptions<ApplicationVariables> options)
        {
            _dbContext = dbContext;
            _applicationVariables = options.Value;
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
                    int memberId = unitOfWork.Commit();
                }
            }

            return View("Index");
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