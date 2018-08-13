using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra.Entities.ViewModels
{
    public class MembershipFeeViewModels
    {
        public int Id { get; set; }

        //[Required]
        //[Display(Name = "Membership Fee")]
        //[DataType(DataType.Currency)]
        //public decimal P_MembershipFee { get; set; }


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
        [Display(Name = "Location Id")]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Location Initials")]
        [DataType(DataType.Text)]
        public char LocationInitials { get; set; }
    }
}
