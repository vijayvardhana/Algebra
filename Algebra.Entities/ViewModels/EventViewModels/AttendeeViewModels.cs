using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class AttendeeViewModels
    {
        public AttendeeViewModels()
        {
            Guest = new List<AttendeeViewModels>();
        }

        public IList<AttendeeViewModels> Guest { get; set; }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [MaxLength(200)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string MobileNumber { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [Display(Name = "Has Guest?")]
        public bool HasGuest { get; set; }

    }
}
