using System.ComponentModel;

namespace BudgetApplication.ViewModels
{
    public class IncomesViewModel
    {
        public int IncomeId { get; set; }

        [DisplayName("Income Name")]
        public string IncomeName { get; set; } = null!;

        [DisplayName("Income Type")]
        public string IncomeType { get; set; } = null!;

        [DisplayName("Payment Frequency")]
        public string PaymentFrequency { get; set; } = null!;
    }
}
