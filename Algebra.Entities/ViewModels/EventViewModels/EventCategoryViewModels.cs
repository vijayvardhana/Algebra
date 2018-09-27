using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.ViewModels
{
    public class EventCategoryViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input Category name!")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input Category Description !")]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

    }
}
