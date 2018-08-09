using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberRepository Members { get; }
        ISpouseRepository Spouses { get; }
        int Commit();
        void Rollback();
    }
}
