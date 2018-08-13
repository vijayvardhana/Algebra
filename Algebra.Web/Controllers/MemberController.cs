using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Algebra.Entities.ViewModels;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.Options;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult Registration(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            IEnumerable<Location> locations;
            IEnumerable<Referrer> referrer;
            IEnumerable<PaymentMode> paymentModes;
            int maxAccId = 0;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                locations = unitOfWork.Locations.GetAll().ToList();
                referrer = unitOfWork.Referrers.GetAll().ToList();
                maxAccId = unitOfWork.Members.GetMaxId(_applicationVariables.InitialAccountNumber);
                paymentModes = unitOfWork.PaymentModes.GetAll().ToList();
            }
            ViewBag.Locations = locations;
            ViewBag.Referrers = referrer;
            ViewBag.AccountId = GetAccountNumber(maxAccId, _applicationVariables.InitialAccountNumber);
            ViewBag.PaymentModes = paymentModes;

            RegistrationFormViewModel RegistrationForm = new RegistrationFormViewModel();
            return View(RegistrationForm);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("api/member/post")]
        public IActionResult Post([FromBody] JObject model)
        {
            if (ModelState.IsValid)
            {
                // ViewBag.LoginUser = User.Identity.Name;
                string[] str = Utils.UnWrapObjects(model, 'o');
                var member = JsonConvert.DeserializeObject<Member>(str[0]);
                var spouse = JsonConvert.DeserializeObject<Spouse>(str[1]);
                List<Dependent> dependents = GetDependentList(str[2]);
                var payment = JsonConvert.DeserializeObject<PaymentDetails>(str[3]);

                member.CreatedBy = User.Identity.Name;
                member.Spouse = spouse;
                member.Dependents = dependents;
                member.Payment = payment;

                using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
                {
                    unitOfWork.Members.Add(member);
                    int memberId = unitOfWork.Commit();
                }
            }

            return View("Registration", model);
        }


        private List<Dependent> GetDependentList(string _str)
        {
            List<Dependent> list = new List<Dependent>();

            string[] _dependents = Utils.UnWrapObjects(JObject.Parse(_str), 'd');
            for (int i = 0; i < _dependents.Length; i++)
            {
                Dependent d = JsonConvert.DeserializeObject<Dependent>(_dependents[i]);
                list.Add(d);
            }

            return list;
        }

        private int GetAccountNumber(int maxAccId, int _initialAccountNumber)
        {
            int accountNo = 0;
            if (maxAccId > 0)
            {
                accountNo = _initialAccountNumber + maxAccId;
            }
            else
            {
                accountNo = _initialAccountNumber;
            }
            return accountNo;
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