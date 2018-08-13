using Algebra.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algebra.Data.Repositories
{
    public class MembershipFeeRepository : Repository<MembershipFee>, IMembershipFeeRepository
    {
        public MembershipFeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    }
}
