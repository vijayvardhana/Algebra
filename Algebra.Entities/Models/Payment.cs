using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class Payment : EntityBase
    {
        #region Constructor
        public Payment() { }
        #endregion Constructor

        #region Properties

        [Required]
        public int MemberId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal MembershipFee { get; set; }

        [MaxLength(50)]
        public string GST { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal TaxAmount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PaymentDate { get; set; }

        [MaxLength(50)]
        public string PaymentMode { get; set; }

        [MaxLength(500)]
        public string ChequeNumber { get; set; }

        [MaxLength(50)]
        public string TransactionId { get; set; }

        [DefaultValue(false)]
        public bool IsDiscountApplicable { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        public short MembershipFeeId { get; set; }

        #endregion Properties

        #region Lazy-Load Properties

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; }

        #endregion
    }
}
