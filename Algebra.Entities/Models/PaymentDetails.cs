using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Algebra.Entities.Models
{
    public class PaymentDetails : EntityBase
    {
        #region Constructor
        public PaymentDetails() { }
        #endregion Constructor

        #region Properties

        [Required]
        public int MemberId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal MembershipFee { get; set; }

        public string GST { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal TaxAmount { get; set; }

        public string PaymentMode { get; set; }

        public string ChequeNumber { get; set; }

        public string TransactionId { get; set; }

        public string Description { get; set; }

        #endregion Properties

        #region Lazy-Load Properties

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        #endregion
    }
}
