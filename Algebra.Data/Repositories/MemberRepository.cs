using System.Collections.Generic;
using Algebra.Entities.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Mapster;
using Algebra.Entities.ViewModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public int GetCountByLocationId(int locationId)
        {
            return _dbContext
                .Members
                .Count(l => l.LocationId == locationId);
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

        public Member GetMemberByAccountNumber(string accountNumber)
        {
            return _dbContext
                .Members
                .SingleOrDefault(c => c.AccountId == accountNumber);
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
                    model.IsNew = false;
                }
                else
                {
                    model.IsNew = true;
                }
                model.Locations = unitOfWork.Locations.GetLocationFeeDropDown(unitOfWork);
                model.Categories = unitOfWork.Categories.GetDropDown(unitOfWork);
                model.Referrers = unitOfWork.Referrers.GetDropDown(unitOfWork);
                model.Modes = unitOfWork.Modes.GetDropDown(unitOfWork);
            };

            return model;
        }

        public RegistrationFormViewModel CreateRegistration(RegistrationFormViewModel model)
        {
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                string accountNumber = GetAccountNumber(unitOfWork, model.LocationId);
                Fee fee = unitOfWork.Fees.GetFeeByLocationId(model.LocationId);

                model.Member = MemberBuilder(accountNumber, model);
                model.Spouse = SpouseBuilder(accountNumber);

                model.Dependent = DependentsBuilder(accountNumber);
                model.Payment = PaymentBuilder(fee, model.MembershipType, model);
                model.Payment.Cheques = ChequeBuilder();

                model.Member.Locations = model.Locations;
                model.Member.Categories = model.Categories;
                model.Member.Referrers = model.Referrers;
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

                model.Spouse = (spouse != null)
                    ? spouse
                    : null;

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
                    if (cheques.Count > 0)
                    {
                        model.Payment.Cheques = cheques;
                    }

                    FeeViewModels fee = unitOfWork
                        .Fees
                        .Get(payment.MembershipFeeId)
                        .Adapt<FeeViewModels>();
                }

                model.Member.Locations = unitOfWork.Locations.GetDropDown(unitOfWork);
                model.Member.Categories = unitOfWork.Categories.GetDropDown(unitOfWork);
                model.Member.Referrers = unitOfWork.Referrers.GetDropDown(unitOfWork);
                model.Payment.Modes = unitOfWork.Modes.GetDropDown(unitOfWork);
            }
            return model;
        }

        #region Healper Methods

        private MemberViewModels MemberBuilder(string accountNumber, RegistrationFormViewModel r)
        {
            MemberViewModels model = new MemberViewModels();
            model.LocationId = r.LocationId;
            model.MembershipType = r.MembershipType;
            model.ReferredBy = r.ReferredBy;
            model.AccountId = accountNumber;
            model.CardId = accountNumber;
            model.IsNew = r.IsNew;
            return model;
        }

        private SpouseViewModels SpouseBuilder(string accountNumber)
        {
            SpouseViewModels model = new SpouseViewModels();
            model.CardId = accountNumber;
            return model;
        }

        private List<DependentViewModels> DependentsBuilder(string accountNumber)
        {
            List<DependentViewModels> model = new List<DependentViewModels>();
            var cardNumber = accountNumber;
            model.Add(new DependentViewModels() { CardId = accountNumber });
            model.Add(new DependentViewModels() { CardId = accountNumber });
            return model;
        }

        private List<ChequeViewModels> ChequeBuilder()
        {
            List<ChequeViewModels> model = new List<ChequeViewModels>();
            model.Add(new ChequeViewModels());
            return model;
        }

        private PaymentViewModel PaymentBuilder(Fee fee, short membershipType, RegistrationFormViewModel r)
        {
            PaymentViewModel model = new PaymentViewModel();
            model.FeeBreakUp = fee.Adapt<FeeViewModels>();

            int GST = Convert.ToInt32(fee.GSTRate);
            model.MembershipFee = MembershipFee(fee, membershipType);
            model.GST = fee.GSTRate;
            model.TaxAmount = (model.MembershipFee * GST / 100);
            model.TotalAmount = model.MembershipFee + model.TaxAmount;
            model.MembershipFeeId = fee.Id;
            model.Modes = r.Modes;
            return model;
        }

        private decimal MembershipFee(Fee fee, short membershipType)
        {
            decimal membershipFee;
            switch (membershipType)
            {
                case 1:
                    membershipFee = fee.Individual;
                    break;
                case 2:
                    membershipFee = fee.Individual + fee.Couple;
                    break;
                case 3:
                    membershipFee = fee.Individual + fee.Couple + fee.Dependent;
                    break;
                case 4:
                    membershipFee = fee.Individual + fee.Dependent;
                    break;
                default:
                    //in case of Complimentary membership
                    membershipFee = 0;
                    break;
            }
            return membershipFee;
        }

        private string GetAccountNumber(IUnitOfWork unitOfWork, int locationId)
        {
            string accountNumber = string.Empty;
            string code = unitOfWork.Locations.GetCodeDigitByLocationId(locationId);
            int count = unitOfWork.Members.GetCountByLocationId(locationId);
            count++; //increasing one by so that new user will get increased account id
            string strCount = (count).ToString();
            accountNumber = code.Remove(code.Length - strCount.Length);
            return $"{accountNumber}{strCount}";
        }

        #endregion Healper Methods
    }
}
