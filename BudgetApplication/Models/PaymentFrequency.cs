using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public partial class PaymentFrequencies
    {
        [Key]
        public int PaymentFrequencyId { get; set; }
        public string? PaymentFrequency { get; set; }
    }
}
