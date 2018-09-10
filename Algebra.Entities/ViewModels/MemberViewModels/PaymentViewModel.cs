using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class PaymentViewModel
    {
        public PaymentViewModel()
        {
            Cheques = new List<ChequeViewModels>();
            FeeBreakUp = new FeeViewModels();

        }
        public IList<ChequeViewModels> Cheques { get; set; }

        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        [Display(Name = "Membership Fee")]
        [DataType(DataType.Currency)]
        public decimal MembershipFee { get; set; }

        [Display(Name = "GST (%)")]
        public string GST { get; set; }

        [Display(Name = "Tax Amount")]
        [DataType(DataType.Currency)]
        public decimal TaxAmount { get; set; }

        [Required]
        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? PaymentDate { get; set; }

        [Display(Name = "Payment Mode")]
        public short PaymentMode { get; set; }

        public IEnumerable<SelectListItem> Modes { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Discount")]
        public bool IsDiscountApplicable { get; set; }

        [Display(Name = "Payee Name")]
        public string PayeeName { get; set; }

        [Display(Name = "Transaction Id (Payment Reference Number)")]
        public string TransactionId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Created { get; set; }

        public int MembershipFeeId { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Display(Name = "Payment Received By")]
        public string PaymentRecievedBy { get; set; }

        public short PaymentStatus { get; set; }

        public FeeViewModels FeeBreakUp { get; set; }

    }
}
