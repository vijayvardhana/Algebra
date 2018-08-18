using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class Token
    {
        #region Constructor
        public Token() { }
        #endregion

        #region Properties
        [Key]
        [Required]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        [MaxLength(50)]
        public string ClientId { get; set; }

        [Column(Order = 2)]
        public int Type { get; set; }

        [Required]
        [Column(Order = 3)]
        [MaxLength(50)]
        public string Value { get; set; }

        [Required]
        [Column(Order = 4)]
        public string UserId { get; set; }

        [Required]
        [Column(Order = 5)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [Column(Order = 6)]
        public DateTime LastModifiedDate { get; set; }
        #endregion

        #region Lazy-Load Properties
        /// <summary>
        /// The user related to this token
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        #endregion
    }
}
