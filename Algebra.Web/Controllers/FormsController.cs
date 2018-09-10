using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Algebra.Data;
using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Algebra.Web.Controllers
{
    [Route("api/[controller]")]
    public class FormsController : Controller
    {
        private ApplicationDbContext _dbContext;
        private CmsDbContext _cmsContext;
        private IEnumerable<SelectListItem> _locations = null;
        private IEnumerable<SelectListItem> _refItems = null;
        private IEnumerable<SelectListItem> _modes = null;
        public FormsController(ApplicationDbContext dbContext, CmsDbContext cmsDbContext)
        {
            _dbContext = dbContext;
            _cmsContext = cmsDbContext;
            LoadDropDowns();
        }

        private void LoadDropDowns()
        {
            using (UnitOfWork uow = new UnitOfWork(_dbContext))
            {
                _locations = uow.Locations.GetDropDown(uow);
                _refItems = uow.Referrers.GetDropDown(uow);
                _modes = uow.Modes.GetDropDown(uow);
            }
        }

        // GET api/<controller>/5
        [HttpGet]
        public IActionResult Index()
        {
            IList<NewMembersFrom> Forms = _cmsContext.GetForms();
            return View(Forms);
        }

        [HttpPost("Export")]
        public IActionResult Export([FromBody]string values)
        {
            if (string.IsNullOrEmpty(values)
                && values.Split(',').Count() == 0)
            {
                return BadRequest("no ids available to export");
            }
            List<string> result = new List<string>();
            string[] items = values.Split(',');
            IList<NewMembersFrom> Forms = _cmsContext.GetForms();

            for (int i = 0; i < items.Length; i++)
            {
                int id = Convert.ToInt32(items[i]);
                NewMembersFrom form = Forms.SingleOrDefault(m => m.Member_Id == id);
                Member member = ObjectMapper(form);

                using(IUnitOfWork uow = new UnitOfWork(_dbContext))
                {
                    try
                    {
                        uow.Members.Add(member);
                        int newId = uow.Commit();
                        if (newId > 0)
                            result.Add($"Success: {member.AccountId}");
                        else
                            result.Add($"Success but not added: {member.AccountId}");
                    }
                    catch (Exception e)
                    {
                        result.Add($"Failed: {member.AccountId}, due to {e.Message}");
                    }
                    
                }
                
            }


            return Ok($"Data exported result : {result.ToString()}");
        }

        #region helper method
        private Member ObjectMapper(NewMembersFrom form)
        {
            Member member = MemberMapper(form);
            Spouse spouse = SpouseMapper(form, member);
            IList<Dependent> dependents = DependentMapper(form, member);
            Payment payment = PaymentMapper(form, member);

            if (spouse != null) member.Spouse = spouse;
            if (dependents != null && dependents.Count > 0) member.Dependents = dependents;
            member.Payments = payment;
            return member;
        }

        private Member MemberMapper(NewMembersFrom f)
        {

            return new Member
            {
                Id = f.Member_Id,
                CreatedDate = f.CreatedDate,
                Gender = ParseGender(f.Member_Gender.Trim()),
                IsDeleted = false,
                MembershipEndDate = f.Member_MembershipEndDate,
                MembershipStartDate = f.Member_MembershipStartDate,
                Status = true,
                UpdatedDate = DateTime.Now,
                CardId = f.Member_CardId.Replace(" ", "-"),
                Email = f.Member_Email,
                ImagePath = f.Member_ImagePath,
                IpAddress = null,
                //RowVersion = 
                AccountId = f.Member_AccountId,
                ReferredBy = ParseReferredBy(f.Member_ReferredBy.Trim()),
                MembershipType = ParseCategory(f.Member_MembershipType.Trim()),
                Title = ParseTitle(f.Member_Title),
                FirstName = f.Member_FirstName,
                MiddleName = f.Member_MiddleName,
                LastName = f.Member_LastName,
                ProfessionalTitle = f.Member_ProfessionalTitle,
                Designation = f.Member_Designation,
                Organization = f.Member_Designation,
                TelephoneNumber = f.Member_PresentTelephone,
                PresentAddress = f.Member_PresentAddress,
                PresentCity = f.Member_PresentCity,
                PresentState = f.Member_PresentState,
                PresentPin = f.Member_PresentPin,
                PermanentAddress = f.Member_PermanentAddress,
                PermanentCity = f.Member_PermanentCity,
                PermanentState = f.Member_PermanentState,
                PermanentPin = f.Member_PermanentPin,
                PrimaryMobileNumber = f.Member_PrimaryMobileNumber,
                SecondaryMobileNumber = f.Member_SecondaryMobileNumber,
                Location = f.Member_LocationId,
                LocationId = ParseLocation(f.Member_LocationId.Trim()),
                FormPath = null,
                CreatedBy = "Exported",
                MaritalStatus = ParseMaritalStatus(f.Member_MaritalStatus.Trim()),
                Occupation = ParseOccupation(f.Member_Occupation.Trim()),
                SponcerId = 0,
                Addressed = f.Member_Addressed,
                MemberDOB = ParseDate(f.Member_DOB.Trim()),
                AnnualIncome = ParseDecimal(f.Member_AnnualIncome.Trim())

            };
        }

        private Spouse SpouseMapper(NewMembersFrom f, Member member)
        {
            if (string.IsNullOrEmpty(f.Spouse_CardId)
                && string.IsNullOrEmpty(f.Spouse_FirstName))
            {
                return null;
            }
            return new Spouse
            {
                CreatedDate = f.CreatedDate,
                Gender = ParseGender(f.Spouse_Gender.Trim()),
                //Id
                IsDeleted = false,
                MembershipEndDate = member.MembershipEndDate,
                MembershipStartDate = member.MembershipStartDate,
                Status = true,
                UpdatedDate = DateTime.Now,
                CardId = f.Spouse_CardId.Replace(" ", "-"),
                Email = f.Spouse_Email,
                ImagePath = f.Spouse_ImagePath,
                IpAddress = null,
                //RowVersion = null,
                MemberId = member.Id,
                Title = ParseTitle(f.Spouse_Title.Trim()),
                FirstName = f.Spouse_FirstName,
                MiddleName = f.Spouse_MiddleName,
                LastName = f.Spouse_LastName,
                PrimaryMobileNumber = f.Spouse_PrimaryMobileNumber,
                SecondaryMobileNumber = f.Spouse_SecondaryMobileNumber,
                TelephoneNumber = f.Spouse_PresentTelephone,
                ProfessionalTitle = f.Spouse_ProfessionalTitle,
                Designation = f.Spouse_Designation,
                Organization = f.Spouse_Organization,
                PresentAddress = f.Spouse_PresentAddress,
                PresentCity = f.Spouse_PresentCity,
                PresentState = f.Spouse_PresentState,
                PresentPin = f.Spouse_PresentPin,
                PermanentAddress = f.Spouse_PermanentAddress,
                PermanentCity = f.Spouse_PermanentCity,
                PermanentState = f.Spouse_PermanentState,
                PermanentPin = f.Spouse_PermanentPin,
                MaritalStatus = ParseMaritalStatus(f.Spouse_MaritalStatus.Trim()),
                Occupation = ParseOccupation(f.Spouse_Occupation.Trim()),
                SponcerId = 0,
                Addressed = f.Spouse_Addressed,
                SpouseDOB = ParseDate(f.Spouse_DOB.Trim()),
                AnnualIncome = ParseDecimal(f.Spouse_AnnualIncome)
            };
        }

        private IList<Dependent> DependentMapper(NewMembersFrom f, Member member)
        {
            List<Dependent> dependents = new List<Dependent>();

            if (!string.IsNullOrEmpty(f.FirstDependent_CardId)
                && !string.IsNullOrEmpty(f.FirstDependent_FirstName)
                )
            {
                dependents.Add(
                    new Dependent
                    {
                        CreatedDate = f.CreatedDate,
                        Gender = ParseGender(f.FirstDependent_Gender.Trim()),
                        IsDeleted = false,
                        MembershipEndDate = member.MembershipEndDate,
                        MembershipStartDate = member.MembershipStartDate,
                        Status = true,
                        UpdatedDate = DateTime.Now,
                        CardId = f.FirstDependent_CardId.Replace(" ", "-"),
                        Email = f.FirstDependent_Email,
                        ImagePath = f.FirstDependent_ImagePath,
                        IpAddress = "",
                        MemberId = member.Id,
                        FirstName = f.FirstDependent_FirstName,
                        MiddleName = f.FirstDependent_MiddleName,
                        LastName = f.FirstDependent_LastName,
                        MobileNumber = f.FirstDependent_MobileNumber,
                        DependentDOB = ParseDate(f.FirstDependent_DOB.Trim())
                    }
                    );

            }
            if (!string.IsNullOrEmpty(f.SecondDependent_CardId)
                && !string.IsNullOrEmpty(f.SecondDependent_FirstName)
                )
            {
                dependents.Add(
                    new Dependent
                    {
                        CreatedDate = f.CreatedDate,
                        Gender = ParseGender(f.SecondDependent_Gender.Trim()),
                        IsDeleted = false,
                        MembershipEndDate = member.MembershipEndDate,
                        MembershipStartDate = member.MembershipStartDate,
                        Status = true,
                        UpdatedDate = DateTime.Now,
                        CardId = f.SecondDependent_CardId.Replace(" ", "-"),
                        Email = f.SecondDependent_Email,
                        ImagePath = f.SecondDependent_ImagePath,
                        IpAddress = "",
                        MemberId = member.Id,
                        FirstName = f.SecondDependent_FirstName,
                        MiddleName = f.SecondDependent_MiddleName,
                        LastName = f.SecondDependent_LastName,
                        MobileNumber = f.SecondDependent_MobileNumber,
                        DependentDOB = ParseDate(f.SecondDependent_DOB.Trim())
                    }
                    );
            }
            return dependents;
        }

        private Payment PaymentMapper(NewMembersFrom f, Member member)
        {
            Payment p = new Payment();
            p.Created = "Exported";
            p.CreatedDate = member.CreatedDate;
            p.UpdatedDate = DateTime.Now;
            p.IsDeleted = false;
            p.IpAddress = "";
            p.MemberId = member.Id;

            p.PaymentMode = ParsePaymentMode(f.PaymentMode.Trim());

            switch (p.PaymentMode)
            {
                //For BankTransfer
                case 1:
                    p.GST = f.BankTransferGST;
                    p.TaxAmount = ParseDecimal(f.BankTransferTaxAmount.Trim());
                    p.MembershipFee = ParseDecimal(f.BankMembershipFee.Trim());
                    p.TotalAmount = ParseDecimal(f.BankTransferTotalAmount.Trim());
                    p.TransactionId = f.BankRRN;
                    p.PaymentStatus = ParsePaymentStatus(f.PaymentStatus.Trim());
                    break;
                //For Cash
                case 2:
                    p.GST = f.CashGST;
                    p.TaxAmount = ParseDecimal(f.CashTaxAmount.Trim());
                    p.MembershipFee = ParseDecimal(f.CreditCardMembershipFee.Trim());
                    p.TotalAmount = ParseDecimal(f.CreditCardTotalAmount.Trim());
                    p.TransactionId = "";
                    p.PaymentStatus = ParsePaymentStatus(f.PaymentStatus.Trim());
                    break;
                //For Cheque
                case 3:
                    p.GST = f.ChequeGST;
                    p.TaxAmount = ParseDecimal(f.ChequeTaxAmount.Trim());
                    p.TotalAmount = ParseDecimal(f.ChequeTotalAmount.Trim());
                    p.MembershipFee = (p.TotalAmount - p.TaxAmount);
                    p.Cheques = ChequeMapper(f);
                    break;
                //For credit card
                case 4:
                    p.PayeeName = f.NameOnCreditCard;
                    p.GST = f.CreditCardGST;
                    p.TaxAmount = ParseDecimal(f.CreditCardTaxAmount.Trim());
                    p.MembershipFee = ParseDecimal(f.CreditCardMembershipFee.Trim());
                    p.TotalAmount = ParseDecimal(f.CashTotalAmount.Trim());
                    p.TransactionId = f.BankRRN;
                    p.PaymentStatus = ParsePaymentStatus(f.PaymentStatus.Trim());
                    break;
                default:
                    break;
            }

            p.PaymentDate = ParseDate(f.PaymentDate.Trim());
            p.IsDiscountApplicable = (f.Payment_MembershipType == "complementry") ? true : false;
            p.Description = f.Description;
            p.BankName = "";
            p.PaymentRecievedBy = $"{f.CreditCardPaymentRecievedBy}, {f.PaymentRecievedBy} ";
            return p;
        }

        private IList<Cheque> ChequeMapper(NewMembersFrom f)
        {
            List<Cheque> cheques = new List<Cheque>();
            cheques.Add(
                new Cheque
                {
                    DrawnOn = f.FirstCheque_DrawnOn,
                    Date = ParseDate(f.FirstCheque_Date.Trim()),
                    Number = f.FirstCheque_Number,
                    Amount = ParseDecimal(f.ChequeTotalAmount.Trim()),
                    ChequeStatus = ParsePaymentStatus(f.PaymentStatus.Trim())
                }
                );
            return cheques;
        }

        private decimal ParseDecimal(string value)
        {
            string amount = (!string.IsNullOrEmpty(value))
                ? value
                : "0.00";
            return Convert.ToDecimal(amount, CultureInfo.InvariantCulture);
        }

        private DateTime ParseDate(string dob)
        {
            if (string.IsNullOrEmpty(dob))
            {
                return DateTime.Now; // for avoiding exception
            }

            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(dob,
                new string[] {
                    "MM.dd.yyyy",
                    "MM-dd-yyyy",
                    "MM/dd/yyyy"
                },
                provider,
                DateTimeStyles.None);
        }

        private short ParseGender(string gender)
        {
            return (gender.Trim() == "Male")
                      ? (short)Enums.Gender.Male
                      : (short)Enums.Gender.Female;
        }

        private short ParseCategory(string type)
        {
            return (type.Trim() == "Family")
                      ? (short)Enums.MembershipCategory.Individual
                      : (short)Enums.MembershipCategory.IndividualCoupleDependent;
        }

        private short ParseTitle(string title)
        {
            short value = 0;
            switch (title.Trim())
            {
                case "Dr":
                    value = Convert.ToInt16(Enums.Title.Dr);
                    break;
                case "Mr":
                case "Mr.":
                    value = Convert.ToInt16(Enums.Title.Mr);
                    break;
                case "Mrs":
                    value = Convert.ToInt16(Enums.Title.Mrs);
                    break;
                case "Ms":
                    value = Convert.ToInt16(Enums.Title.Ms);
                    break;
            }
            return value;
        }

        private short ParseLocation(string location)
        {
            short value = 4;

            //switch (location)
            //{
            //    case "Gurgaon":
            //        value = Utils.GetValueByText(_locations, location);
            //        break;
            //    case "Bangalore":
            //        value = Utils.GetValueByText(_locations, location);
            //        break;
            //    case "Chennai":
            //        value = Utils.GetValueByText(_locations, location);
            //        break;
            //    case "Delhi":
            //        value = Utils.GetValueByText(_locations, location);
            //        break;
            //}
            return value;
        }

        private short ParseReferredBy(string refer)
        {
            short id = 0;

            switch (refer.Trim())
            {
                case "Anjali Gulati":
                    id = Utils.GetValueByText(_refItems, refer);
                    break;
                case "Neena Tejpal":
                    id = Utils.GetValueByText(_refItems, refer);
                    break;
                case "Palms":
                    id = Utils.GetValueByText(_refItems, refer);
                    break;
                case "Payal Puri":
                    id = Utils.GetValueByText(_refItems, refer);
                    break;
                case "Sheuli Sethi":
                    id = Utils.GetValueByText(_refItems, refer);
                    break;
                case "Shoma Chaudhury":
                    id = Utils.GetValueByText(_refItems, refer);
                    break;
                case "Tarun Tejpal":
                    id = Utils.GetValueByText(_refItems, refer);
                    break;
            }
            return id;
        }

        private short ParseMaritalStatus(string status)
        {
            short value = 0;
            switch (status)
            {
                case "Single":
                    value = Convert.ToInt16(Enums.MaritalStatus.Single);
                    break;
                case "Marriad":
                case "Married":
                case "Marrired":
                    value = Convert.ToInt16(Enums.MaritalStatus.Married);
                    break;
                case "Divorced":
                case "Divoreced":
                    value = Convert.ToInt16(Enums.MaritalStatus.Divorced);
                    break;
            }
            return value;
        }

        private short ParseOccupation(string occupation)
        {
            short value = 0;
            switch (occupation)
            {
                case "Salaried":
                    value = Convert.ToInt16(Enums.Occupation.Salaried);
                    break;
                case "Self Employed":
                    value = Convert.ToInt16(Enums.Occupation.SelfEmployed);
                    break;
                case "Business":
                    value = Convert.ToInt16(Enums.Occupation.Business);
                    break;
            }
            return value;
        }

        private short ParsePaymentMode(string mode)
        {
            short value = 0;

            switch (mode)
            {
                case "Banktransfer":
                    value = Utils.GetValueByText(_modes, "Bank Transfer");
                    break;
                case "Cash":
                    value = Utils.GetValueByText(_modes, mode);
                    break;
                case "Cheque":
                    value = Utils.GetValueByText(_modes, mode);
                    break;
                case "Credit":
                    value = Utils.GetValueByText(_modes, "Credit Card");
                    break;
                default:
                    value = Utils.GetValueByText(_modes, "Mix Mode");
                    break;
            }
            return value;
        }

        private short ParsePaymentStatus(string status)
        {
            short value = 0;
            switch (status)
            {
                case "Cleared":
                    value = Convert.ToInt16(Enums.PaymentStatus.Cleared);
                    break;
                case "Others":
                    value = Convert.ToInt16(Enums.PaymentStatus.Others);
                    break;
                case "Clearing Process":
                    value = Convert.ToInt16(Enums.PaymentStatus.ClearingProcess);
                    break;
            }
            return value;
        }
        #endregion

    }
}
