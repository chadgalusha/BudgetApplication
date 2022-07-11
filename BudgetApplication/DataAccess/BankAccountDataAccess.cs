using BudgetApplication.Models;
using BudgetApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BudgetApplication.DataAccess
{
    public class BankAccountDataAccess
    {
        private readonly BudgetApplicationContext _context;

        public BankAccountDataAccess(BudgetApplicationContext context)
        {
            _context = context;
        }

        public List<BankAccountsViewModel> GetUserBankAccounts(string userId)
        {
            var bankAccountsViewModel = (from b in _context.BankAccounts
                                    join bat in _context.BankAccountTypes on b.BankAccountTypeId equals bat.BankAccountTypeId
                                    where b.UserId == userId
                                    select new BankAccountsViewModel
                                    {
                                        BankAccountId = b.BankAccountId,
                                        BankAccountName = b.BankAccountName,
                                        BankAccountType = bat.BankAccountType,
                                        Balance = b.Balance
                                    }).ToList();
            return bankAccountsViewModel;
        }

        public async Task<List<string>> GetListUserBankAccountNamesAsync(string userId)
        {
            return await _context.BankAccounts.Where(a => a.UserId == userId).Select(a => a.BankAccountName).ToListAsync();
        }

        public async Task<BankAccounts> GetUserBankAccountByBankAccountIdAsync(int bankAccountId)
        {
            return await _context.BankAccounts.Where(b => b.BankAccountId == bankAccountId).FirstOrDefaultAsync();
        }

        public async Task EditBankAccountAsync(BankAccounts userBankAccount)
        {
            try
            {
                _context.BankAccounts.Update(userBankAccount);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Log.Error("Error, bank account not updated: {errormessage}", e.Message);
            }
        }

        public async Task CreateBankAccountAsync(BankAccounts newBankAccount)
        {
            try
            {
                _context.BankAccounts.Add(newBankAccount);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Log.Error("Error, bank account not created: {errormessage}", e.Message);
            }
        }

        public async Task<int> DeleteBankAccountAsync(int bankAccountId)
        {
            try
            {
                BankAccounts userBankAccount = await GetUserBankAccountByBankAccountIdAsync(bankAccountId);
                _context.BankAccounts.Remove(userBankAccount);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {
                Log.Error("Error, bank account not deleted: {errormessage}", e.Message);
                return 0;
            }
        }
    }
}
