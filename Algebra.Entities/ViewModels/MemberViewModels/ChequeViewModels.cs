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
        public string C_Number { get; set; }

        [Required]
        [Display(Name="Amount")]
        public decimal C_Amount { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime C_Date { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Bank Name")]
        public string C_BankName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Drawn On")]
        public string C_DrawnOn { get; set; }

    }
}
