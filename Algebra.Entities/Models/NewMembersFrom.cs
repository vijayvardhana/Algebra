using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class NewMembersFrom
    {
        [Key]
        [Column("max_id")]
        public int MemberId { get; set; }
        [Column("location_cat")]
        public string MembershipType { get; set; }
        [Column("Gurgaon")]
        public string LocationId { get; set; }
        [Column("Unique_id")]
        public string AccountId { get; set; }
        [Column("Account_id")]
        public string CardId { get; set; }
        [Column("start_fd")]
        public DateTime MembershipStartDate { get; set; }
        [Column("end_fd")]
        public DateTime MembershipEndDate { get; set; }
        [Column("Refenceby")]
        public string ReferredBy { get; set; }
        [Column("Initial")]
        public string Title { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("Middle_Name")]
        public string MiddleName { get; set; }
        [Column("Last_Name")]
        public string LastName { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        public string dbo { get; set; }
        public string Marital_Satus { get; set; }
        public string File_input { get; set; }
        public string Occupation { get; set; }
        public string Title_Profession { get; set; }
        public string ODesignation { get; set; }
        public string OOrganization { get; set; }
        public string OSalaried { get; set; }
        public string STitle_Profession { get; set; }
        public string SDesignation { get; set; }
        public string SOrganization { get; set; }
        public string Mobile_No1 { get; set; }
        public string Mobile_No2 { get; set; }
        public string EMail1 { get; set; }
        public string EMail2 { get; set; }
        public string Present_Residentials { get; set; }
        public string Resid_state { get; set; }
        public string Resid_city { get; set; }
        public string Resid_pin { get; set; }
        public string Res_Telephone { get; set; }
        public string Correspondence_Address { get; set; }
        public string Corresp_state { get; set; }
        public string Corresp_city { get; set; }
        public string Corresp_pin { get; set; }
        public string hw_addressed { get; set; }
        public string SpAccount_id { get; set; }
        public string SpInitial { get; set; }
        public string Spfirst_name { get; set; }
        public string SpMiddle_Name { get; set; }
        public string SpLast_Name { get; set; }
        public string Spgender { get; set; }
        public string Spdbo { get; set; }
        public string SpMarital_Satus { get; set; }
        public string SpFile_input { get; set; }
        public string SpOccupation { get; set; }
        public string SpTitle_Profession { get; set; }
        public string SpODesignation { get; set; }
        public string SpOOrganization { get; set; }
        public string SpOSalaried { get; set; }
        public string SpSTitle_Profession { get; set; }
        public string SpSDesignation { get; set; }
        public string SpSOrganization { get; set; }
        public string SPOffice_Address { get; set; }
        public string SPOffice_state { get; set; }
        public string SPoff_city { get; set; }
        public string SPOff_pin { get; set; }
        public string SPOffice_Telephone { get; set; }
        public string SPMobile_No1 { get; set; }
        public string SPMobile_No2 { get; set; }
        public string SPEMail1 { get; set; }
        public string SPEMail2 { get; set; }
        public string SPPresent_Residentials { get; set; }
        public string SPResid_state { get; set; }
        public string SPResid_city { get; set; }
        public string SPResid_pin { get; set; }
        public string SPRes_Telephone { get; set; }
        public string SPCorrespondence_Address { get; set; }
        public string SpCorresp_state { get; set; }
        public string SpCorresp_city { get; set; }
        public string SPCorresp_pin { get; set; }
        public string SPhw_addressed { get; set; }
        public string SPstatus { get; set; }
        public string Dt1Account_id { get; set; }
        public string Dt1first_name { get; set; }
        public string Dt1Middle_Name { get; set; }
        public string Dt1Last_Name { get; set; }
        public string Dt1gender { get; set; }
        public string Dt1pdbo { get; set; }
        public string Dt1File_input { get; set; }
        public string Dt1Mobileno { get; set; }
        public string Dt1Emailid { get; set; }
        public string Dt1Pstatus { get; set; }
        public string Dt2Account_id { get; set; }
        public string Dt2first_name { get; set; }
        public string Dt2Middle_Name { get; set; }
        public string Dt2Last_Name { get; set; }
        public string Dt2gender { get; set; }
        public string Dt2pdbo { get; set; }
        public string Dt2File_input { get; set; }
        public string Dt2Mobileno { get; set; }
        public string Dt2Emailid { get; set; }
        public string Dt2Pstatus { get; set; }
        public string ini_mfree { get; set; }
        public string modp { get; set; }
        public string ind_amount { get; set; }
        public string ind_cpername { get; set; }
        public string ind_costno { get; set; }
        public string ind_perdetails { get; set; }
        public string chbankdrawn1 { get; set; }
        public string chdate1 { get; set; }
        public string Algebra { get; set; }
        public string ch_status { get; set; }
        public string Creditamount { get; set; }
        public string chdate2 { get; set; }
        public string Creditholder { get; set; }
        public string CardRRN { get; set; }
        public string Bankname { get; set; }
        public string bankdate { get; set; }
        public string Bankamount { get; set; }
        public string bankRRN { get; set; }
        public string status { get; set; }
        public string cry_sta { get; set; }
        public DateTime? cre_date { get; set; }
        public DateTime mod_date { get; set; }
        public DateTime end_date { get; set; }
        public string cashtaxper { get; set; }
        public string cashtaxamount { get; set; }
        public string cashtotalamount { get; set; }
        public string Chequetaxper { get; set; }
        public string Chequetaxamount { get; set; }
        public string Chequetotalamount { get; set; }
        public string Credittaxamount { get; set; }
        public string Credittaxper { get; set; }
        public string Credittotalamount { get; set; }
        public string bnktaxper { get; set; }
        public string Bnktaxamount { get; set; }
        public string bnktotalamount { get; set; }
    }
}
