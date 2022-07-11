using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public partial class IncomeTypes
    {
        public IncomeTypes()
        {
            Incomes = new HashSet<Incomes>();
        }

        [Key]
        public int IncomeTypeId { get; set; }

        [DisplayName("Income Type")]
        [StringLength(50, ErrorMessage = "Bank Account Type must not exceed 50 characters. ")]
        public string? IncomeType { get; set; }

        public virtual ICollection<Incomes> Incomes { get; set; }
    }
}
