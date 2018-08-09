using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Algebra.Entities.Models
{
    public class MembershipFee : EntityBase
    {
        #region Properties
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(10,4)")]
        public decimal Individual { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal Couple { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal Dependent { get; set; }

        [Required]
        [MaxLength(50)]
        public string GSTRate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal GSTAmount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)")]
        public decimal TotalAmount { get; set; }

        public int LocationId { get; set; }

        public char LocationInitials { get; set; }

        #endregion Properties
    }
}
