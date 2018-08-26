using System.Collections.Generic;
using Algebra.Entities.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Mapster;
using Algebra.Entities.ViewModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Algebra.Data.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Member> GetLatestMembers(int count)
        {
            return _dbContext.Members//.ToList();
                .OrderBy(m => m.CreatedDate)
                .Take(count)
                .ToList();
        }
        public int GetMaxId()
        {
            if (_dbContext.Members.Any())
            {
                return _dbContext.Members.Max(i => i.Id);
            }
            else
            {
                return 0;
            }

        }

        public IEnumerable<Member> GetMembersWithSpouseAndDependents()
        {
            return _dbContext.Members
                .Include(i => i.Spouse)
                .Include(i => i.Dependents)
                .ToList();
        }

        public RegistrationFormViewModel CreateMember(int id)
        {
            RegistrationFormViewModel model = new RegistrationFormViewModel();

            using (var unitOfWork = new UnitOfWork(_dbContext))
            {

                var m = unitOfWork.Members.Get(id);
                if (m != null)
                {
                    model.Id = m.Id;
                    model.LocationId = m.LocationId;
                    model.MembershipType = m.MembershipType;
                    model.ReferredBy = m.ReferredBy;
                }

                // model.Locations = unitOfWork.Locations.GetDropDown(unitOfWork);
                model.Locations = unitOfWork.Locations.GetLocationFeeDropDown(unitOfWork);
                model.Categories = unitOfWork.Categories.GetDropDown(unitOfWork);
                model.Referrers = unitOfWork.Referrers.GetDropDown(unitOfWork);
            };

            return model;
        }

        public RegistrationFormViewModel CreateRegistration(RegistrationFormViewModel r)
        {
            RegistrationFormViewModel model = new RegistrationFormViewModel();

            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                model.LocationId = r.LocationId;
                model.MembershipType = r.MembershipType;
                model.ReferredBy = r.ReferredBy;

                model.Locations = unitOfWork.Locations.GetLocationFeeDropDown(unitOfWork);
                model.Categories = unitOfWork.Categories.GetDropDown(unitOfWork);
                model.Referrers = unitOfWork.Referrers.GetDropDown(unitOfWork);

                model.Member = MemberBuilder(unitOfWork, r);
                model.Spouse = SpouseBuilder(unitOfWork, r);
                model.Dependent = DependentsBuilder(unitOfWork, r);
                model.Payment = PaymentBuilder(unitOfWork, r);
            }

            return model;
        }

        public Member SetMemberEntities(JObject model)
        {
            string[] str = Utils.UnWrapObjects(model, 'o');
            var member = JsonConvert.DeserializeObject<Member>(str[0]);
            var spouse = JsonConvert.DeserializeObject<Spouse>(str[1]);
            List<Dependent> dependents = Utils.GetObjectList<Dependent>(str[2], 'd');
            var payment = JsonConvert.DeserializeObject<Payment>(str[3]);
            List<Cheque> cheques = Utils.GetObjectList<Cheque>(str[4], 'c');

            dependents.RemoveAll(c=>c.CardId == null);

            if (!string.IsNullOrEmpty(spouse.CardId))
            {
                member.Spouse = spouse;
            }

            if (dependents.Count > 0)
            {
                member.Dependents = dependents;
            }

            if (cheques.Count > 0)
            {
                payment.Cheques = cheques;
            }
            member.Payments = payment;

            return member;
        }

        #region Healper Methods

        private MemberViewModels MemberBuilder(IUnitOfWork unitOfWork, RegistrationFormViewModel r)
        {
            MemberViewModels model = new MemberViewModels();

            var m = unitOfWork.Members.Get(r.Id);
            if (m != null)
            {
                model.M_LocationId = m.LocationId;
                model.M_MembershipType = m.MembershipType;
                model.M_ReferredBy = m.ReferredBy;
                model.M_AccountId = m.AccountId;
                model.M_CardId = m.CardId;
            }
            else
            {
                model.M_LocationId = r.LocationId;
                model.M_MembershipType = r.MembershipType;
                model.M_ReferredBy = r.ReferredBy;
                model.M_AccountId = GetAccountNumber(unitOfWork, r.LocationId);
                model.M_CardId = model.M_AccountId;
                model.M_Location = unitOfWork.Locations.GetLocationById(r.LocationId);
            }

            return model;
        }

        private SpouseViewModels SpouseBuilder(IUnitOfWork unitOfWork, RegistrationFormViewModel r)
        {
            SpouseViewModels spouse = new SpouseViewModels();
            var s = unitOfWork.Spouses.GetSpouseByMemberId(r.Id);
            if (s != null)
            {
                spouse.S_CardId = s.CardId;
            }
            else
            {
                spouse.S_CardId = GetAccountNumber(unitOfWork, r.LocationId);
            }
            return spouse;
        }

        private List<DependentViewModels> DependentsBuilder(UnitOfWork unitOfWork, RegistrationFormViewModel r)
        {
            List<DependentViewModels> dependents = new List<DependentViewModels>();
            var dependentList = unitOfWork.Dependents.GetDependentsByMemberId(r.Id);
            var cardNumber = GetAccountNumber(unitOfWork, r.LocationId);
            if (dependentList.Count > 0)
            {
                foreach (var d in dependentList)
                {
                    dependents.Add(d.Adapt<DependentViewModels>());
                }
            }
            else
            {
                dependents.Add(new DependentViewModels() { D_CardId = cardNumber });
                dependents.Add(new DependentViewModels() { D_CardId = cardNumber });
            }
            return dependents;
        }

        private PaymentViewModel PaymentBuilder(IUnitOfWork unitOfWork, RegistrationFormViewModel r)
        {
            PaymentViewModel m = new PaymentViewModel();
            var modes = unitOfWork.Modes.GetDropDown(unitOfWork);
            Fee f = unitOfWork.Fees.GetFeeByLocationId(r.LocationId);
            if (f != null)
            {
                int GST = Convert.ToInt32(f.GSTRate);
                switch (r.MembershipType)
                {
                    case 1:
                        m.P_MembershipFee = f.Individual;
                        break;
                    case 2:
                        m.P_MembershipFee = f.Individual + f.Couple;
                        break;
                    case 3:
                        m.P_MembershipFee = f.Individual + f.Couple + f.Dependent;
                        break;
                    case 4:
                        m.P_MembershipFee = f.Individual + f.Dependent;
                        break;
                    default:
                        //in case of Complimentary membership
                        m.P_MembershipFee = 0;
                        break;
                }

                m.P_GST = f.GSTRate;
                m.P_TaxAmount = (m.P_MembershipFee * GST / 100);
                m.P_TotalAmount = m.P_MembershipFee + m.P_TaxAmount;
                m.P_MembershipFeeId = f.Id;
                m.P_FeeBreakUp = f.Adapt<FeeViewModels>();
            }
            m.Modes = modes;
            return m;
        }

        private string GetAccountNumber(IUnitOfWork unitOfWork, int locId)
        {
            string accountNumber = string.Empty;
            Location l = unitOfWork.Locations.Get(locId);
            int m = unitOfWork.Members.GetMaxId();

            if (m != 0)
            {
                accountNumber = string.Format("{0}{1}", l.Digits, m.ToString());
            }
            else
            {
                accountNumber = string.Format("{0}{1}", l.Digits, "1");
            }

            int exceslen = accountNumber.Length - 4;
            return string.Format("{0}{1}", l.Code, accountNumber.Remove(1, exceslen));
        }

        #endregion Healper Methods
    }
}
