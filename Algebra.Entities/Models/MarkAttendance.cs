using System;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.Models
{
    public class MarkAttendance : EntityBase
    {
        [Required]
        public int EventId{ get; set; }

        [Required]
        public int AttenderId { get; set; }

        [Required]
        public bool IsMember { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; }
    }
}
