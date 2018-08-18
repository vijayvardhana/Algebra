using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Algebra.Entities.ViewModels
{
    public class CategoryViewModels
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public string Type { get; set; }

        [MaxLength(400)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Created By")]
        public string Created { get; set; }

        [Display(Name = "Is Active")]
        public bool IsDeleted { get; set; }


    }
}
