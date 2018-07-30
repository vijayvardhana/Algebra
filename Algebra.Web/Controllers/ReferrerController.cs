using System;
using System.Collections.Generic;
using System.Linq;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class ReferrerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ReferrerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Referrer> referrers;
            using (var unitOfWork = new UnitOfWork(_dbContext)) {
                referrers = unitOfWork.Referrers.GetAll();
            }
            return View(referrers);
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
