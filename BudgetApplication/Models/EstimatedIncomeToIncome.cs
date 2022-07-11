using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public partial class EstimatedIncomeToIncome
    {
        [Key]
        public int EstimatedIncomeId { get; set; }

        [Key]
        public int IncomeId { get; set; }
    }
}
