using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public partial class Incomes
    {
        public Incomes()
        {
            IncomeHistories = new HashSet<IncomeHistory>();
        }

        [Key]
        public int IncomeId { get; set; }

        [Required]
        [DisplayName("Income Name")]
        [StringLength(100, ErrorMessage = "Bank Account Type must not exceed 50 characters. ")]
        public string? IncomeName { get; set; }

        [Required]
        public string? UserId { get; set; }

        [DisplayName("Income Type")]
        public int? IncomeTypeId { get; set; }

        [DisplayName("Frequency")]
        public int? PaymentFrequencyTypeId { get; set; }

        public virtual IncomeTypes? IncomeType { get; set; }
        public virtual ICollection<IncomeHistory> IncomeHistories { get; set; }
    }
}
