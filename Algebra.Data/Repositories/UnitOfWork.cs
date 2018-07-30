using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
            Members = new MemberRepository(_dbContext);
            Spouses = new SpouseRepository(_dbContext);
            Locations = new LocationRepository(_dbContext);
            Users = new UserRepository(_dbContext);
            Referrers = new ReferrerRepository(_dbContext);
        }

        public IMemberRepository Members { get; private set; }
        public ISpouseRepository Spouses { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IUserRepository Users { get; set; }
        public IReferrerRepository Referrers { get; set; }


        int IUnitOfWork.Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
