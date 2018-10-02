using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Algebra.Entities.ViewModels
{
    public class EventViewModels
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EndDate { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [Required]
        [MaxLength(100)]
        public string Format { get; set; }

        [Required]
        [MaxLength(255)]
        public string[] Categories { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [Required]
        [MaxLength(255)]
        public string[] Speakers { get; set; }
        public IEnumerable<SelectListItem> SpeakerList { get; set; }

        [Required]
        [MaxLength(255)]
        public string[] Sponsors { get; set; }

        public IEnumerable<SelectListItem> SponsorList { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }

    }
}
