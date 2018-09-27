using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class SpeakerViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input Speaker name!")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input Speaker description")]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string Logo { get; set; }
    }
}
