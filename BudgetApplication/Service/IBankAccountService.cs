using BudgetApplication.Models;
using BudgetApplication.ViewModels;

namespace BudgetApplication.Service
{
    public interface IBankAccountService
    {
        Task<int> CreateBankAccountAsync(string userId, string bankAccountName, int bankAccountTypeId, decimal balance);
        Task<int> DeleteBankAccountAsync(int bankAccountId);
        Task EditBankAccountAsync(int bankAccountId, string bankAccountName, int bankAccountTypeId, decimal balance);
        int GetBankAccountTypeByBankAccountId(int bankAccountId);
        Task<BankAccounts> GetUserBankAccountByBankAccountIdAsync(int bankAccountId);
        List<BankAccountsViewModel> GetUserBankAccounts(string userId);
        Task ModifyBalanceAsync(int bankAccountId, decimal balance);
    }
}