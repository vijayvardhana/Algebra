using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SearchController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[HttpGet]
        //[Route("MemberByAccountNumber")]
        //public JsonResult MemberByAccountNumber(string text)
        //{
        //    Member member = null;

        //    using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
        //    {
        //        member = unitOfWork
        //            .Members
        //            .GetMemberByAccountNumber(text.Trim());
        //    }
        //    return Json(member);
        //}

        [HttpGet("MemberByAccountNumber")]
        public IActionResult MemberByAccountNumber(string namelike)
        {
            Member member = null;
            using (IUnitOfWork unitOfWork = new UnitOfWork(_dbContext))
            {
                member = unitOfWork
                    .Members
                    .GetMemberByAccountNumber(namelike.Trim());
            }
            if (member==null)
            {
                return NotFound(namelike);
            }
            return Ok(member);
        }

    }
}
