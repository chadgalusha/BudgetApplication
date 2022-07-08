using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public class BankAccountTypes
    {
        [Key]
        public int BankAccountTypeId {get;set;}
        [DisplayName("Bank Account Type")]
        [StringLength(50, ErrorMessage = "Bank Account Type must not exceed 50 characters. ")]
        public string BankAccountType { get; set; } = null!;
    }
}
