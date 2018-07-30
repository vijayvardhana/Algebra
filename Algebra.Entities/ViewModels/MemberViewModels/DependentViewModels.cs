using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class DependentViewModels
    {
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.Text)]
        public string MobileNumber { get; set; }
    }
}
