using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Algebra.Entities.Models
{
    public class Fee : EntityBase
    {
        #region Properties
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(10,4)", Order =1)]
        public decimal Individual { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)", Order =2)]
        public decimal Couple { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)", Order =3)]
        public decimal Dependent { get; set; }

        [Required]
        [Column(Order = 4)]
        [MaxLength(50)]
        public string GSTRate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)", Order =5)]
        public decimal GSTAmount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,4)", Order =6)]
        public decimal TotalAmount { get; set; }

        [Required]
        [Column(Order = 7)]
        public int LocationId { get; set; }

        #endregion Properties
    }
}
