using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Algebra.Entities.Models
{
    public class PaymentMode
    {
        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Mode { get; set; }

        [Required]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        #endregion
    }
}
