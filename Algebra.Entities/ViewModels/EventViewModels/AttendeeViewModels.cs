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

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNumber { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Please Enter Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address! i.e. 'somename@domain.com'")]
        public string Email { get; set; }

        [Display(Name = "Has Guest?")]
        public bool HasGuest { get; set; }

        public int AttenderntId { get; set; }

    }
}
