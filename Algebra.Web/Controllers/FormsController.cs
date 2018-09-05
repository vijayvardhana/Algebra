using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algebra.Data;
using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class FormsController : Controller
    {
        private ApplicationDbContext _dbContext;
        private CmsDbContext _cmsContext;
        public FormsController(ApplicationDbContext dbContext, CmsDbContext cmsDbContext)
        {
            _dbContext = dbContext;
            _cmsContext = cmsDbContext;
        }

        // GET api/<controller>/5
        [HttpGet]
        public IActionResult Index()
        {
            IList<NewMembersFrom> Forms = _cmsContext.GetForms();
            return View(Forms);
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
