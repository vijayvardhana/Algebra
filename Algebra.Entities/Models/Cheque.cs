using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class Cheque : EntityBase
    {
        public int PaymentId { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal Amount { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string BankName { get; set; }

        [MaxLength(100)]
        public string DrawnOn { get; set; }

        [ForeignKey("PaymentId")]
        public virtual Payment Payments { get; set; }

    }
}
