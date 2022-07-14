using BudgetApplication.Models;
using BudgetApplication.ViewModels;

namespace BudgetApplication.DataAccess
{
    public interface IBankAccountDataAccess
    {
        Task CreateBankAccountAsync(BankAccounts newBankAccount);
        Task<int> DeleteBankAccountByIdAsync(int bankAccountId);
        Task EditBankAccountAsync(BankAccounts userBankAccount);
        Task<List<string>> GetListUserBankAccountNamesAsync(string userId);
        Task<BankAccounts> GetUserBankAccountByBankAccountIdAsync(int bankAccountId);
        List<BankAccountsViewModel> GetUserBankAccounts(string userId);
    }
}