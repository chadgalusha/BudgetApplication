using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public partial class BankAccounts
    {
        [Key]
        public int BankAccountId { get; set; }

        public string? UserId { get; set; }

        [DisplayName("Bank Account Name")]
        public string? BankAccountName { get; set; }

        [DisplayName("Bank Account Type Id")]
        public int? BankAccountTypeId { get; set; }

        [RegularExpression(@"^\d+\.\d{0, 2}$", ErrorMessage = "Must be in a numerical format (123, 123.45, etc.)")]
        [Range(-9999999999999999.99, 9999999999999999.99, ErrorMessage = "Balance must be a numerical value")]
        public decimal Balance { get; set; }
    }
}
