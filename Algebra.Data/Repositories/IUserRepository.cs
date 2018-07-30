using Algebra.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Data.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetUserByLocation(string location);
    }
}
