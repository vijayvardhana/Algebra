using Algebra.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Data.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Payment GetPaymentByMemberId(int id);
    }
}
