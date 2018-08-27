﻿using Algebra.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public interface IChequeRepository : IRepository<Cheque>
    {
        List<Cheque> GetChequesByPaymentId(int id);
    }
}
