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
        public decimal? EstimatedAmount { get; set; }

        [DisplayName("Frequency")]
        public int? PaymentFrequencyTypeId { get; set; }

        [DisplayName("Estimated Income Date")]
        public DateTime? EstimatedIncomeDate { get; set; }

        [DisplayName("Is Fulfilled")]
        public bool? IsFulfilled { get; set; }
    }
}
