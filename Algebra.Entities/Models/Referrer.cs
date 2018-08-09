using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class Referrer
    {
        #region Constructor
        public Referrer() { }
        #endregion Constructor

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(200)]
        public string ImagePath { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        #endregion Properties
    }
}
