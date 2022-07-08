using BudgetApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplication.DataAccess
{
    public class BankAccountTypeDataAccess
    {
        private readonly BudgetApplicationContext _context;

        public BankAccountTypeDataAccess(BudgetApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<BankAccountTypes>> GetBankAccountTypesAsync()
        {
            return await _context.BankAccountTypes.ToListAsync();
        }

        public DbSet<BankAccountTypes> GetBankAccountTypes()
        {
            return _context.BankAccountTypes;
        }
    }
}
