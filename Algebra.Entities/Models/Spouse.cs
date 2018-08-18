using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.Models
{
    public class Spouse:MembershipBase
    {

        #region Constructor
        public Spouse() { }
        #endregion Constructor

        #region Properties

        [Required]
        [Column(Order = 1)]
        public int MemberId { get; set; }

        [Required]
        [Column(Order = 3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Column(Order = 4)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Column(Order = 5)]
        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [Column(Order = 6)]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [Column(Order = 7)]
        [MaxLength(50)]
        public string PrimaryMobileNumber { get; set; }

        [Column(Order = 8)]
        [MaxLength(50)]
        public string SecondaryMobileNumber { get; set; }

        [Column(Order = 9)]
        [MaxLength(50)]
        public string TelephoneNumber { get; set; }

        [Column(Order = 12)]
        [MaxLength(50)]
        public string ProfessionalTitle { get; set; }

        [Column(Order = 13)]
        [MaxLength(100)]
        public string Designation { get; set; }

        [Column(Order = 14)]
        [MaxLength(100)]
        public string Organization { get; set; }

        [Column(Order = 15)]
        [MaxLength(200)]
        public string PresentAddress { get; set; }

        [Column(Order = 16)]
        [MaxLength(200)]
        public string CorrespondenceAddress { get; set; }

        

        #endregion
        #region Lazy-Load Properties

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        #endregion
    }
}
