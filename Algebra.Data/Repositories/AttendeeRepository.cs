using Algebra.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class AttendeeRepository : Repository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public Attendee GetAttendeeByMobileNumber(string number)
        {
            return _dbContext
                .Attendees
                .SingleOrDefault(m => m.MobileNumber == number);
        }

        public Attendee GetAttendeeByEmailId(string email)
        {
            return _dbContext
                .Attendees
                .SingleOrDefault(e => e.Email == email);
        }

        public IList<Attendee> GetGuest(int id)
        {
            return _dbContext
                .Attendees
                .AsNoTracking()
                .Where(a => a.AttenderntId == id)
                .ToList();
        }

        public Attendee GetAttendeeWithGuest(int id)
        {
            Attendee attendee = new Attendee();
            attendee = _dbContext
                .Attendees
                .AsNoTracking()
                .SingleOrDefault(a => a.Id == id);
            if (attendee.HasGuest)
            {
                attendee.Guest = GetGuest(id);
            }
            return attendee;
        }

        public string GuestOf(int attenderntId)
        {
            if (attenderntId > 0)
            {
                var attendee = _dbContext
                                .Attendees
                                .SingleOrDefault(a => a.Id == attenderntId);

                return $"{attendee.FirstName} {attendee.LastName}";
            }
            else
            {
                return "Self";
            }

        }
    }
}
