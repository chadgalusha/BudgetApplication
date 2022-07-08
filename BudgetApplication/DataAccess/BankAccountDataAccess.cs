using BudgetApplication.Models;
using BudgetApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public async Task<BankAccounts> GetBankAccountTypeByBankAccountIdAsync(int bankAccountId)
        {
            return await _context.BankAccounts.FindAsync(bankAccountId);
        }

        public async void EditBankAccountAsync(BankAccounts userBankAccount)
        {
            try
            {
                _context.BankAccounts.Update(userBankAccount);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async void CreateBankAccountAsync(BankAccounts newBankAccount)
        {
            try
            {
                _context.BankAccounts.Add(newBankAccount);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
