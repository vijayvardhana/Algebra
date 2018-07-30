using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Algebra.Entities.ViewModels;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {

        private ApplicationDbContext _dbContext;
        public MemberController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //// GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<Member> Get()
        //{
        //    IEnumerable<Member> members;
        //    using (var unitOfWork = new UnitOfWork(_dbContext))
        //    {


        //        members = unitOfWork.Members.GetLatestMembers(20);

        //        //return members;
        //        // Example1
        //        //var course = unitOfWork.Courses.Get(1);

        //        //// Example2
        //        //var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

        //        //// Example3
        //        //var author = unitOfWork.Authors.GetAuthorWithCourses(1);
        //        //unitOfWork.Courses.RemoveRange(author.Courses);
        //        //unitOfWork.Authors.Remove(author);
        //        //unitOfWork.Complete();
        //    }
        //    return members; 
        //}

        ////// GET api/<controller>/5
        ////[HttpGet("{id}")]
        ////public string Get(int id)
        ////{
        ////    return "value";
        ////}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}



        [HttpGet]
        public IActionResult Registration(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            IEnumerable<Location> locations;
            IEnumerable<Referrer> referrer;
            using(var unitOfWork = new UnitOfWork(_dbContext))
            {
                locations = unitOfWork.Locations.GetAll().ToList();
                referrer = unitOfWork.Referrers.GetAll().ToList();
            }
             ViewBag.Locations = locations;
             ViewBag.Referrers = referrer;
            //MemberViewModels member = new MemberViewModels();
            RegistrationFormViewModel RegistrationForm = new RegistrationFormViewModel();
            return View(RegistrationForm);
        }


    }
}
