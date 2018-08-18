using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Algebra.Entities.ViewModels
{
    public class FeeViewModels
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Individual Fee")]
        [DataType(DataType.Currency)]
        public decimal Individual { get; set; }

        [Required]
        [Display(Name = "Spouse Fee")]
        [DataType(DataType.Currency)]
        public decimal Couple { get; set; }

        [Required]
        [Display(Name = "Dependent Fee")]
        [DataType(DataType.Currency)]
        public decimal Dependent { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "GST Rate (%)")]
        public string GSTRate { get; set; }

        [Required]
        [Display(Name = "GST Amount")]
        [DataType(DataType.Currency)]
        public decimal GSTAmount { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [Required]
        [Display(Name = "Location Name")]
        public int LocationId { get; set; }

        public IEnumerable<SelectListItem> Locations { get; set; }
        
    }
}
