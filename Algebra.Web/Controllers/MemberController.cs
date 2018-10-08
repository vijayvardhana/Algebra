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
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IToastNotification _toastNotification;

        public MemberController(ApplicationDbContext dbContext, IToastNotification toastNotification)
        {
            _dbContext = dbContext;
            _toastNotification = toastNotification;
        }

        // GET: api/<controller>
        [HttpGet("Index")]
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

        [HttpGet("AddMember")]
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

        [HttpPost("AddMember")]
        public IActionResult AddMember(RegistrationFormViewModel m)
        {
            RegistrationFormViewModel model;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                if (m.IsNew == false)
                {
                    model = unitOfWork.Members.GetRegistrationViewModels(m.Id);
                    model.LocationId = m.LocationId;
                    model.MembershipType = m.MembershipType;
                    model.ReferredBy = m.ReferredBy;
                }
                else
                {
                    model = FillDropDowns(unitOfWork, m);
                    model = unitOfWork.Members.CreateRegistration(m);
                    model.CreatedBy = User.Identity.Name;
                }
            }
            return View("Registration", model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("post")]
        public IActionResult Post([FromBody] JObject model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(BadRequestMessage(ModelState.Values));
            }

            using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
            {
                Member m = unitOfWork.Members.SetMemberEntities(model);
                var member = unitOfWork.Members.GetMemberByAccountNumber(m.AccountId);
                string opr = string.Empty;
                m.CreatedBy = User.Identity.Name;

                try
                {
                    if (member != null)
                    {
                        opr = "updated";
                        unitOfWork.Members.Update(m);
                        unitOfWork.Commit();
                        return Ok(OkMessage(opr, m.AccountId));
                    }
                    else
                    {
                        opr = "added";
                        unitOfWork.Members.Add(m);
                        int successId = unitOfWork.Commit();
                        if (successId > 0)
                            return Ok(OkMessage(opr, m.AccountId));
                    }
                }
                catch (Exception e)
                {
                    return BadRequest($"Error occured while {opr} : '{e.Message}'");
                    throw;
                }
            }

            return View(); ;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("get")]
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

        private string OkMessage(string opr, string accountNumber)
        {
            return $"SUCCESS : The member with account number '{accountNumber}' has been {opr}.";
        }

        private object BadRequestMessage(ModelStateDictionary.ValueEnumerable values)
        {
            string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            return $"WARNING : model state is not valid! {messages}";
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

//JObject obj = JObject.Parse(model.ToString());
//string objValue = ((JProperty)obj.Last)
//    .Value["IsNew"]
//    .ToString()
//    .ToLower();
//bool isNew = Convert.ToBoolean(objValue);