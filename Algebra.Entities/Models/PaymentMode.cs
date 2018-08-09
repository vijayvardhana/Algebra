using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class PaymentMode
    {
        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Mode { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        #endregion
    }
}
