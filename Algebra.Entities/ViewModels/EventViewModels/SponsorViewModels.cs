using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class SponsorViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input Sponsor name!")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input sponsor description")]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }
    }
}
