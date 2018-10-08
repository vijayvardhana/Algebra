using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algebra.Data.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        IEnumerable<Member> GetLatestMembers(int count);

        int GetMaxId();

        int GetCountByLocationId(int locationId);

        IEnumerable<Member> GetMembersWithSpouseAndDependents();

        Task<Member> GetMemberByAccountNumberAsync(string accountNumber);

        RegistrationFormViewModel CreateMember(int id);

        RegistrationFormViewModel CreateRegistration(RegistrationFormViewModel m);

        Member SetMemberEntities(JObject model);

        Member GetMemberById(int id);

        Member GetMemberByAccountNumber(string accountNumber);

        RegistrationFormViewModel GetRegistrationViewModels(int id);
    }
}
