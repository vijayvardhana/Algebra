using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Algebra.Entities.ViewModels
{
    public class ChequeViewModels
    {
        public int PaymentId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name="Cheque Number")]
        public string Number { get; set; }

        [Required]
        [Display(Name="Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Drawn On")]
        public string DrawnOn { get; set; }

    }
}
