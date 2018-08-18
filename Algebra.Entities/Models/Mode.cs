using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class Mode : EntityBase
    {
        #region Properties

        [Required]
        [Column(Order = 1)]
        [MaxLength(50)]
        public string Text { get; set; }

        [Required]
        [Column(Order = 2)]
        [MaxLength(500)]
        public string Description { get; set; }


        #endregion
    }
}
