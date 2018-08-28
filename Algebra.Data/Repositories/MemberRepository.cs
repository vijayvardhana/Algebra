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

        public Member GetMemberById(int id)
        {
            return _dbContext
                .Members
                .SingleOrDefault(i => i.Id == id);
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

            dependents.RemoveAll(c => c.CardId == null);

            member.Spouse = (!string.IsNullOrEmpty(spouse.CardId)) 
                ? member.Spouse = spouse 
                : null;

            member.Dependents = (dependents.Count > 0) 
                ? dependents 
                : null;

            payment.Cheques = (cheques.Count > 0) 
                ? cheques 
                : null;

            member.Payments = payment;

            return member;
        }

        public RegistrationFormViewModel GetRegistrationViewModels(int id)
        {
            RegistrationFormViewModel model = new RegistrationFormViewModel();
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {

                Member member = unitOfWork
                    .Members.Get(id);
                if (member != null)
                {
                    model.Member = member.Adapt<MemberViewModels>();
                }

                SpouseViewModels spouse = unitOfWork
                    .Spouses
                    .GetSpouseByMemberId(id)
                    .Adapt<SpouseViewModels>();
                if (spouse != null)
                {
                    model.Spouse = spouse;
                }

                List<DependentViewModels> dependents = unitOfWork
                    .Dependents
                    .GetDependentsByMemberId(id)
                    .Adapt<List<DependentViewModels>>();
                if (dependents.Count > 0)
                {
                    model.Dependent = dependents;
                }

                PaymentViewModel payment = unitOfWork
                    .Payments
                    .GetPaymentByMemberId(id)
                    .Adapt<PaymentViewModel>();
                if (payment != null)
                {
                    model.Payment = payment;
                    List<ChequeViewModels> cheques = unitOfWork
                        .Cheques
                        .GetChequesByPaymentId(payment.Id)
                        .Adapt<List<ChequeViewModels>>();
                    if(cheques.Count > 0)
                    {
                        model.Payment.Cheques = cheques;
                    }
                }
            }
            return model;
        }

        #region Healper Methods

        private MemberViewModels MemberBuilder(IUnitOfWork unitOfWork, RegistrationFormViewModel r)
        {
            MemberViewModels model = new MemberViewModels();

            var m = unitOfWork.Members.Get(r.Member.Id);
            if (m != null)
            {
                model.LocationId = m.LocationId;
                model.MembershipType = m.MembershipType;
                model.ReferredBy = m.ReferredBy;
                model.AccountId = m.AccountId;
                model.CardId = m.CardId;
            }
            else
            {
                model.LocationId = r.LocationId;
                model.MembershipType = r.MembershipType;
                model.ReferredBy = r.ReferredBy;
                model.AccountId = GetAccountNumber(unitOfWork, r.LocationId);
                model.CardId = model.AccountId;
                model.Location = unitOfWork.Locations.GetLocationById(r.LocationId);
            }

            return model;
        }

        private SpouseViewModels SpouseBuilder(IUnitOfWork unitOfWork, RegistrationFormViewModel r)
        {
            SpouseViewModels spouse = new SpouseViewModels();
            var s = unitOfWork.Spouses.GetSpouseByMemberId(r.Member.Id);
            if (s != null)
            {
                spouse.CardId = s.CardId;
            }
            else
            {
                spouse.CardId = GetAccountNumber(unitOfWork, r.LocationId);
            }
            return spouse;
        }

        private List<DependentViewModels> DependentsBuilder(UnitOfWork unitOfWork, RegistrationFormViewModel r)
        {
            List<DependentViewModels> dependents = new List<DependentViewModels>();
            var dependentList = unitOfWork.Dependents.GetDependentsByMemberId(r.Member.Id);
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
                dependents.Add(new DependentViewModels() { CardId = cardNumber });
                dependents.Add(new DependentViewModels() { CardId = cardNumber });
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
                        m.MembershipFee = f.Individual;
                        break;
                    case 2:
                        m.MembershipFee = f.Individual + f.Couple;
                        break;
                    case 3:
                        m.MembershipFee = f.Individual + f.Couple + f.Dependent;
                        break;
                    case 4:
                        m.MembershipFee = f.Individual + f.Dependent;
                        break;
                    default:
                        //in case of Complimentary membership
                        m.MembershipFee = 0;
                        break;
                }

                m.GST = f.GSTRate;
                m.TaxAmount = (m.MembershipFee * GST / 100);
                m.TotalAmount = m.MembershipFee + m.TaxAmount;
                m.MembershipFeeId = f.Id;
                m.FeeBreakUp = f.Adapt<FeeViewModels>();
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
