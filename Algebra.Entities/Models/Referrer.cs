using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class Referrer : EntityBase
    {
        #region Constructor
        public Referrer() { }
        #endregion Constructor

        #region Properties

        [Required]
        [Column(Order = 1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(Order = 2)]
        [MaxLength(10)]
        public string Code { get; set; }

        [Column(Order = 3)]
        [MaxLength(200)]
        public string ImagePath { get; set; }

        #endregion Properties
    }
}
