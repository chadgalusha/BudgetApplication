using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public partial class EstimatedIncomeAmount
    {
        [Key]
        public int EstimatedIncomeId { get; set; }

        [Required]
        [DisplayName("Estimated Amount")]
        [RegularExpression(@"^\d+\.\d{0, 2}$", ErrorMessage = "Must be in a numerical format (123, 123.45, etc.)")]
        [Range(-9999999999999999.99, 9999999999999999.99, ErrorMessage = "Balance must be a numerical value")]
        public decimal? EstimatedAmount { get; set; }

        [DisplayName("Frequency")]
        public int? PaymentFrequencyTypeId { get; set; }

        [DisplayName("Estimated Income Date")]
        public DateTime? EstimatedIncomeDate { get; set; }

        [DisplayName("Is Fulfilled")]
        public bool? IsFulfilled { get; set; }
    }
}
