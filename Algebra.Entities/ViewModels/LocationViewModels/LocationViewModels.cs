
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class LocationViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please input location name!")]
        [Display(Name="Location Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input location code (i.e. ALD for Delhi) !")]
        [Display(Name= "Location Code")]
        [DataType(DataType.Text)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please input location Address!")]
        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

    }
}
