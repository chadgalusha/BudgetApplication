using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public partial class IncomeHistory
    {
        [Key]
        public int IncomeHistoryId { get; set; }

        [Required]
        public int? IncomeId { get; set; }

        [DisplayName("Income Amount")]
        public decimal? IncomeAmount { get; set; }

        [DisplayName("Income Date")]
        public DateTime? IncomeDate { get; set; }

        public virtual Incomes? Income { get; set; }
    }
}
