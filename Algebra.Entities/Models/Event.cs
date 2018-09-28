using System;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.Models
{
    public class Event : EntityBase
    {
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [MaxLength(100)]
        public string Format { get; set; }

        [MaxLength(255)]
        public string Categories { get; set; }

        [MaxLength(255)]
        public string Speakers { get; set; }

        [MaxLength(255)]
        public string Sponsors { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }
    }
}
