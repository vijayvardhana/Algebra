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

        [Required(ErrorMessage = "Please input location Initials (i.e. D for Delhi) !")]
        [Display(Name= "Location Initials")]
        [DataType(DataType.Text)]
        public char Initials { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

    }
}
