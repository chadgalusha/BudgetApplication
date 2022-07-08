namespace BudgetApplication.ViewModels
{
    public class BankAccountsViewModel
    {
        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; } = null!;
        public string BankAccountType { get; set; } = null!;
        public decimal Balance { get; set; }
    }
}
