﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
   public class Dependent: MembershipBase
    {
        #region Constructor
        public Dependent() { }
        #endregion Constructor

        #region Properties

        [Required]
        public int MemberId { get; set; }

        [Required]
        public string Name { get; set; }


        public string MobileNumber { get; set; }

        #endregion Properties

        // Navigation properties
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
}
