using Algebra.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algebra.Data.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        IEnumerable<ApplicationUser> IUserRepository.GetUserByLocation(string location)
        {
            return _dbContext.Users.Where(u => u.Location == location).ToList();
        }
    }
}
