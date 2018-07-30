using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Algebra.Entities.Models
{
    public class Location : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public char Initials { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

    }
}
