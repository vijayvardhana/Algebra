using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Algebra.Entities.Models
{
    public class Referrer
    {
        #region Constructor
        public Referrer() { }
        #endregion Constructor

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string ImagePath { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        #endregion Properties
    }
}
