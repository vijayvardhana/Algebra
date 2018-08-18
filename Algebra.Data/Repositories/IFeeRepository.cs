using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface IFeeRepository: IRepository<Fee>
    {
        FeeViewModels CreateFee(int id);
    }
}