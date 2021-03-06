﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Algebra.Entities.Models
{
    public class Speaker : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }
        
        [MaxLength(50)]
        public string MobileNumber { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }
    }
}
