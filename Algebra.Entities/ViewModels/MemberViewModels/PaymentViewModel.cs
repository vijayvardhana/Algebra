using System;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class PaymentViewModel
    {
        [Required]
        public int P_MemberId { get; set; }

        [Required]
        [Display(Name = "Membership Fee")]
        [DataType(DataType.Currency)]
        public decimal P_MembershipFee { get; set; }

        [Display(Name = "GST (%)")]
        public string P_GST { get; set; }

        [Display(Name = "Tax Amount")]
        [DataType(DataType.Currency)]
        public decimal P_TaxAmount { get; set; }

        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime P_PaymentDate { get; set; }

        [Display(Name = "Payment Mode")]
        public string P_PaymentMode { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        public decimal P_TotalAmount { get; set; }

        [Display(Name = "Discount")]
        public bool P_IsDiscountApplicable { get; set; }

        [Display(Name = "Cheque Number")]
        public string P_ChequeNumber { get; set; }

        [Display(Name = "Transaction Id")]
        public string P_TransactionId { get; set; }

        [Display(Name = "Description")]
        public string P_Description { get; set; }

        public short P_MembershipFeeId { get; set; }

    }
}
