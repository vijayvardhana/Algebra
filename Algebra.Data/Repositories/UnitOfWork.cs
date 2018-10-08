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
            Modes = new ModeRepository(_dbContext);
            Fees = new FeeRepository(_dbContext);
            Categories = new CategoryRepository(_dbContext);
            Dependents = new DependentRepository(_dbContext);
            Cheques = new ChequeRepository(_dbContext);
            Payments = new PaymentRepository(_dbContext);

            Events = new EventRepository(_dbContext);
            EventCategories = new EventCategoryRepository(_dbContext);
            Speakers = new SpeakerRepository(_dbContext);
            Sponsors = new SponsorRepository(_dbContext);
            Attendees = new AttendeeRepository(_dbContext);
            Attendance = new MarkAttendanceRepository(_dbContext);
        }

        public IMemberRepository Members { get; private set; }
        public ISpouseRepository Spouses { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IUserRepository Users { get; set; }
        public IReferrerRepository Referrers { get; set; }
        public IModeRepository Modes { get; set; }
        public IFeeRepository Fees { get; set; }
        public ICategoryRepository Categories { get; set; }
        public IDependentRepository Dependents { get; set; }
        public IPaymentRepository Payments { get; set; }
        public IChequeRepository Cheques { get; set; }

        public IEventRepository Events { get; set; }
        public IEventCategoryRepository EventCategories { get; set; }
        public ISpeakerRepository Speakers { get; set; }
        public ISponsorRepository Sponsors { get; set; }
        public IAttendeeRepository Attendees { get; set; }
        public IMarkAttendanceRepository Attendance { get; set; }

        public int Commit()
        {
            return _dbContext.SaveChanges();
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
