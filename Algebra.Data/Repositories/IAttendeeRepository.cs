using Algebra.Entities.Models;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface IAttendeeRepository : IRepository<Attendee>
    {
        Attendee GetAttendeeByMobileNumber(string number);
        Attendee GetAttendeeByEmailId(string email);
        IList<Attendee> GetGuest(int AttendeeId);
        Attendee GetAttendeeWithGuest(int id);
        string GuestOf(int AttendeeId);
    }
}
