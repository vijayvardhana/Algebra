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

        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Payment Mode")]
        public string PaymentMode { get; set; }

        public IEnumerable<SelectListItem> Modes { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Discount")]
        public bool IsDiscountApplicable { get; set; }

        [Display(Name = "Cheque Number")]
        public string ChequeNumber { get; set; }

        [Display(Name = "Transaction Id")]
        public string TransactionId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Created { get; set; }

        public int MembershipFeeId { get; set; } 

        public FeeViewModels FeeBreakUp { get; set; }

    }
}
