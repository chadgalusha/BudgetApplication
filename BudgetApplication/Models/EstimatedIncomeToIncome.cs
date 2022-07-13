using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApplication.Models
{
    public partial class EstimatedIncomeToIncome
    {
        [Key, Column(Order = 0)]
        public int EstimatedIncomeId { get; set; }

        [Key, Column(Order = 1)]       
        public int IncomeId { get; set; }
    }
}
