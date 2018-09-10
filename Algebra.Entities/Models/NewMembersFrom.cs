using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class NewMembersFrom
    {
        [Key]
        [Column("max_id")]
        public int Member_Id { get; set; }
        [Column("location_cat")]
        public string Member_MembershipType { get; set; }
        [Column("Gurgaon")]
        public string Member_LocationId { get; set; }
        [Column("Unique_id")]
        public string Member_AccountId { get; set; }
        [Column("Account_id")]
        public string Member_CardId { get; set; }
        [Column("start_fd")]
        public DateTime Member_MembershipStartDate { get; set; }
        [Column("end_fd")]
        public DateTime Member_MembershipEndDate { get; set; }
        [Column("Refenceby")]
        public string Member_ReferredBy { get; set; }
        [Column("Initial")]
        public string Member_Title { get; set; }
        [Column("first_name")]
        public string Member_FirstName { get; set; }
        [Column("Middle_Name")]
        public string Member_MiddleName { get; set; }
        [Column("Last_Name")]
        public string Member_LastName { get; set; }
        [Column("gender")]
        public string Member_Gender { get; set; }
        [Column("dbo")]
        public string Member_DOB { get; set; }
        [Column("Marital_Satus")]
        public string Member_MaritalStatus { get; set; }
        [Column("File_input")]
        public string Member_ImagePath { get; set; }
        [Column("Occupation")]
        public string Member_Occupation { get; set; }
        [Column("Title_Profession")]
        public string Member_ProfessionalTitle { get; set; }
        [Column("ODesignation")]
        public string Member_Designation { get; set; }
        [Column("OOrganization")]
        public string Member_Organization { get; set; }
        [Column("OSalaried")]
        public string Member_AnnualIncome { get; set; }
        [Column("STitle_Profession")]
        public string Member_OtherProfessionalTitle { get; set; }
        [Column("SDesignation")]
        public string Member_OtherDesignation { get; set; }
        [Column("SOrganization")]
        public string Member_OtherOrganization { get; set; }
        [Column("Mobile_No1")]
        public string Member_PrimaryMobileNumber { get; set; }
        [Column("Mobile_No2")]
        public string Member_SecondaryMobileNumber { get; set; }
        [Column("EMail1")]
        public string Member_Email { get; set; }
        [Column("EMail2")]
        public string Member_OtherEmail { get; set; }
        [Column("Present_Residentials")]
        public string Member_PresentAddress { get; set; }
        [Column("Resid_state")]
        public string Member_PresentState { get; set; }
        [Column("Resid_city")]
        public string Member_PresentCity { get; set; }
        [Column("Resid_pin")]
        public string Member_PresentPin { get; set; }
        [Column("Res_Telephone")]
        public string Member_PresentTelephone { get; set; }
        [Column("Correspondence_Address")]
        public string Member_PermanentAddress { get; set; }
        [Column("Corresp_state")]
        public string Member_PermanentState { get; set; }
        [Column("Corresp_city")]
        public string Member_PermanentCity { get; set; }
        [Column("Corresp_pin")]
        public string Member_PermanentPin { get; set; }
        [Column("hw_addressed")]
        public string Member_Addressed { get; set; }

        /// <summary>
        /// Spouse details start here
        /// </summary>
        [Column("SpAccount_id")]
        public string Spouse_CardId { get; set; }
        [Column("SpInitial")]
        public string Spouse_Title { get; set; }
        [Column("Spfirst_name")]
        public string Spouse_FirstName { get; set; }
        [Column("SpMiddle_Name")]
        public string Spouse_MiddleName { get; set; }
        [Column("SpLast_Name")]
        public string Spouse_LastName { get; set; }
        [Column("Spgender")]
        public string Spouse_Gender { get; set; }
        [Column("Spdbo")]
        public string Spouse_DOB { get; set; }
        [Column("SpMarital_Satus")]
        public string Spouse_MaritalStatus { get; set; }
        [Column("SpFile_input")]
        public string Spouse_ImagePath { get; set; }
        [Column("SpOccupation")]
        public string Spouse_Occupation { get; set; }
        [Column("SpTitle_Profession")]
        public string Spouse_ProfessionalTitle { get; set; }
        [Column("SpODesignation")]
        public string Spouse_Designation { get; set; }
        [Column("SpOOrganization")]
        public string Spouse_Organization { get; set; }
        [Column("SpOSalaried")]
        public string Spouse_AnnualIncome { get; set; }
        [Column("SpSTitle_Profession")]
        public string Spouse_OtherProfessionalTitle { get; set; }
        [Column("SpSDesignation")]
        public string Spouse_OtherDesignation { get; set; }
        [Column("SpSOrganization")]
        public string Spouse_OtherOrganization { get; set; }
        [Column("SPOffice_Address")]
        public string Spouse_OfficeAddress { get; set; }
        [Column("SPOffice_state")]
        public string Spouse_OfficeState { get; set; }
        [Column("SPoff_city")]
        public string Spouse_OfficeCity { get; set; }
        [Column("SPOff_pin")]
        public string Spouse_OfficePin { get; set; }
        [Column("SPOffice_Telephone")]
        public string Spouse_OfficeTelephone { get; set; }
        [Column("SPMobile_No1")]
        public string Spouse_PrimaryMobileNumber { get; set; }
        [Column("SPMobile_No2")]
        public string Spouse_SecondaryMobileNumber { get; set; }
        [Column("SPEMail1")]
        public string Spouse_Email { get; set; }
        [Column("SPEMail2")]
        public string Spouse_OtherEmail { get; set; }
        [Column("SPPresent_Residentials")]
        public string Spouse_PresentAddress { get; set; }
        [Column("SPResid_state")]
        public string Spouse_PresentState { get; set; }
        [Column("SPResid_city")]
        public string Spouse_PresentCity { get; set; }
        [Column("SPResid_pin")]
        public string Spouse_PresentPin { get; set; }
        [Column("SPRes_Telephone")]
        public string Spouse_PresentTelephone { get; set; }
        [Column("SPCorrespondence_Address")]
        public string Spouse_PermanentAddress { get; set; }
        [Column("SpCorresp_state")]
        public string Spouse_PermanentState { get; set; }
        [Column("SpCorresp_city")]
        public string Spouse_PermanentCity { get; set; }
        [Column("SPCorresp_pin")]
        public string Spouse_PermanentPin { get; set; }
        [Column("SPhw_addressed")]
        public string Spouse_Addressed { get; set; }
        [Column("SPstatus")]
        public string Spouse_Status { get; set; }

        /// <summary>
        /// First Dependent details start here
        /// </summary>
        [Column("Dt1Account_id")]
        public string FirstDependent_CardId { get; set; }
        [Column("Dt1first_name")]
        public string FirstDependent_FirstName { get; set; }
        [Column("Dt1Middle_Name")]
        public string FirstDependent_MiddleName { get; set; }
        [Column("Dt1Last_Name")]
        public string FirstDependent_LastName { get; set; }
        [Column("Dt1gender")]
        public string FirstDependent_Gender { get; set; }
        [Column("Dt1pdbo")]
        public string FirstDependent_DOB { get; set; }
        [Column("Dt1File_input")]
        public string FirstDependent_ImagePath { get; set; }
        [Column("Dt1Mobileno")]
        public string FirstDependent_MobileNumber { get; set; }
        [Column("Dt1Emailid")]
        public string FirstDependent_Email { get; set; }
        [Column("Dt1Pstatus")]
        public string FirstDependent_Status { get; set; }

        /// <summary>
        /// Second Dependent details start here
        /// </summary>
        [Column("Dt2Account_id")]
        public string SecondDependent_CardId { get; set; }
        [Column("Dt2first_name")]
        public string SecondDependent_FirstName { get; set; }
        [Column("Dt2Middle_Name")]
        public string SecondDependent_MiddleName { get; set; }
        [Column("Dt2Last_Name")]
        public string SecondDependent_LastName { get; set; }
        [Column("Dt2gender")]
        public string SecondDependent_Gender { get; set; }
        [Column("Dt2pdbo")]
        public string SecondDependent_DOB { get; set; }
        [Column("Dt2File_input")]
        public string SecondDependent_ImagePath { get; set; }
        [Column("Dt2Mobileno")]
        public string SecondDependent_MobileNumber { get; set; }
        [Column("Dt2Emailid")]
        public string SecondDependent_Email { get; set; }
        [Column("Dt2Pstatus")]
        public string SecondDependent_Status { get; set; }

        /// <summary>
        /// Payment details start here
        /// </summary>
        [Column("ini_mfree")]
        public string Payment_MembershipType { get; set; }
        [Column("modp")]
        public string PaymentMode { get; set; }
        [Column("ind_amount")]
        public string CashMembershipFee { get; set; }

        [Column("ind_cpername")]
        public string PaymentRecievedBy { get; set; }

        [Column("ind_costno")]
        public string ind_costno { get; set; }

        [Column("ind_perdetails")]
        public string Description { get; set; }

        /// <summary>
        /// First Cheque details start here
        /// </summary>
        [Column("chbankdrawn1")]
        public string FirstCheque_DrawnOn { get; set; }
        [Column("chdate1")]
        public string FirstCheque_Date { get; set; }
        [Column("Algebra")]
        public string FirstCheque_Number { get; set; }
        [Column("ch_status")]
        public string PaymentStatus { get; set; }
        [Column("Creditamount")]
        public string CreditCardMembershipFee { get; set; }

        [Column("chdate2")]
        public string Payment_Date { get; set; }

        [Column("Creditholder")]
        public string NameOnCreditCard { get; set; }
        [Column("CardRRN")]
        public string CreditCardTransactionId { get; set; }
        [Column("Bankname")]
        public string BankName { get; set; }
        [Column("bankdate")]
        public string PaymentDate { get; set; }
        [Column("Bankamount")]
        public string BankMembershipFee { get; set; }
        [Column("bankRRN")]
        public string BankRRN { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("cry_sta")]
        public string CreditCardPaymentRecievedBy { get; set; }
        [Column("cre_date")]
        public DateTime? EndDate { get; set; }
        [Column("mod_date")]
        public DateTime CreatedDate { get; set; }
        [Column("end_date")]
        public DateTime UpdatedDate { get; set; }
        [Column("cashtaxper")]
        public string CashGST { get; set; }
        [Column("cashtaxamount")]
        public string CashTaxAmount { get; set; }
        [Column("cashtotalamount")]
        public string CashTotalAmount { get; set; }
        [Column("Chequetaxper")]
        public string ChequeGST { get; set; }
        [Column("Chequetaxamount")]
        public string ChequeTaxAmount { get; set; }
        [Column("Chequetotalamount")]
        public string ChequeTotalAmount { get; set; }
        [Column("Credittaxamount")]
        public string CreditCardTaxAmount { get; set; }
        [Column("Credittaxper")]
        public string CreditCardGST { get; set; }
        [Column("Credittotalamount")]
        public string CreditCardTotalAmount { get; set; }
        [Column("bnktaxper")]
        public string BankTransferGST { get; set; }
        [Column("Bnktaxamount")]
        public string BankTransferTaxAmount { get; set; }
        [Column("bnktotalamount")]
        public string BankTransferTotalAmount { get; set; }
    }
}
