using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using Algebra.Data;
using Algebra.Data.Repositories;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private ApplicationDbContext _dbContext;
        public LocationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Index()
        {
            //IList<Location> location;
            IEnumerable<Location> location; 
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                //location = unitOfWork.Locations.GetAll().ToList();
                location = unitOfWork.Locations.GetAll();
            }

            return View(location);
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
