using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            PaymentModes = new PaymentModeRepository(_dbContext);
        }

        public IMemberRepository Members { get; private set; }
        public ISpouseRepository Spouses { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IUserRepository Users { get; set; }
        public IReferrerRepository Referrers { get; set; }
        public IPaymentModeRepository PaymentModes { get; set; }


        int IUnitOfWork.Commit()
        {
            
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                //return e.Message;
                //This either returns a error string, or null if it can’t handle that error
                //var error = CheckHandleError(e);
                //if (error != null)
                //{
                //    return error; //return the error string
                //}
                throw; //couldn’t handle that error, so rethrow
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
