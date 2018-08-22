using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using System.Collections.Generic;

namespace Algebra.Data.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        IEnumerable<Member> GetLatestMembers(int count);

        int GetMaxId();

        IEnumerable<Member> GetMembersWithSpouseAndDependents();

        RegistrationFormViewModel CreateMember(int id);

        RegistrationFormViewModel CreateRegistration(RegistrationFormViewModel m);
    }
}
