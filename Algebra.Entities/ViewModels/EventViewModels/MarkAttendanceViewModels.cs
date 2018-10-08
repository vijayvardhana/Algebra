using Algebra.Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class MarkAttendanceViewModels
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public int AttenderId { get; set; }

        [Required]
        public bool IsMember { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; } = DateTime.Now;

        public Event Event { get; set; }
    }
}
