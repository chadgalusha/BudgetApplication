using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public partial class PaymentFrequencyTypes
    {
        [Key]
        public int PaymentFrequencyTypeId { get; set; }
        [DisplayName("Payment Frequency")]
        public string? PaymentFrequencyType { get; set; }
    }
}
