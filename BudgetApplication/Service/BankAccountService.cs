using BudgetApplication.DataAccess;
using BudgetApplication.Models;
using BudgetApplication.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BudgetApplication.Service
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountDataAccess _bankAccountDataAccess;

        public BankAccountService(IBankAccountDataAccess bankAccountDataAccess)
        {
            _bankAccountDataAccess = bankAccountDataAccess;
        }

        public List<BankAccountsViewModel> GetUserBankAccounts(string userId)
        {
            List<BankAccountsViewModel> bankAccountsList = new();

            var bankAccountsModel = _bankAccountDataAccess.GetUserBankAccounts(userId);

            foreach (var bankAccount in bankAccountsModel)
            {
                BankAccountsViewModel b = new()
                {
                    BankAccountId = bankAccount.BankAccountId,
                    BankAccountName = bankAccount.BankAccountName,
                    BankAccountType = bankAccount.BankAccountType,
                    Balance = bankAccount.Balance
                };
                bankAccountsList.Add(b);
            }
            return bankAccountsList;
        }

        public async Task<BankAccounts> GetUserBankAccountByBankAccountIdAsync(int bankAccountId)
        {
            return await _bankAccountDataAccess.GetUserBankAccountByBankAccountIdAsync(bankAccountId);
        }

        public int GetBankAccountTypeByBankAccountId(int bankAccountId)
        {
            var currentBankAccount = _bankAccountDataAccess.GetUserBankAccountByBankAccountIdAsync(bankAccountId).Result;
            return (int)currentBankAccount.BankAccountTypeId;
        }

        public async Task EditBankAccountAsync(int bankAccountId, string bankAccountName, int bankAccountTypeId, decimal balance)
        {
            BankAccounts userBankAccount = await _bankAccountDataAccess.GetUserBankAccountByBankAccountIdAsync(bankAccountId);

            if (userBankAccount.BankAccountName != bankAccountName)
            {
                userBankAccount.BankAccountName = bankAccountName;
            }

            if (userBankAccount.BankAccountTypeId != bankAccountTypeId)
            {
                userBankAccount.BankAccountTypeId = bankAccountTypeId;
            }

            if (userBankAccount.Balance != balance)
            {
                userBankAccount.Balance = balance;
            }

            await _bankAccountDataAccess.EditBankAccountAsync(userBankAccount);
        }

        public async Task ModifyBalanceAsync(int bankAccountId, decimal balance)
        {
            BankAccounts userBankAccount = _bankAccountDataAccess.GetUserBankAccountByBankAccountIdAsync(bankAccountId).Result;

            if (userBankAccount.Balance != balance)
            {
                userBankAccount.Balance = balance;
            }

            await _bankAccountDataAccess.EditBankAccountAsync(userBankAccount);
        }

        public async Task<int> CreateBankAccountAsync(string userId, string bankAccountName, int bankAccountTypeId, decimal balance)
        {
            var listUserBankAccountNames = _bankAccountDataAccess.GetListUserBankAccountNamesAsync(userId).Result;

            foreach (var accountName in listUserBankAccountNames)
            {
                if (accountName.ToLower().Equals(bankAccountName.ToLower()))
                {
                    return 0;
                }
            }

            BankAccounts newBankAccount = new()
            {
                UserId = userId,
                BankAccountName = bankAccountName,
                BankAccountTypeId = bankAccountTypeId,
                Balance = balance
            };

            await _bankAccountDataAccess.CreateBankAccountAsync(newBankAccount);

            return 1;
        }

        public async Task<int> DeleteBankAccountAsync(int bankAccountId)
        {
            return await _bankAccountDataAccess.DeleteBankAccountByIdAsync(bankAccountId);
        }
    }
}
