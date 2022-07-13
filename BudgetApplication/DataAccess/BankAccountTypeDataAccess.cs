using BudgetApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BudgetApplication.DataAccess
{
    public class BankAccountTypeDataAccess : ITypeDataAccess<BankAccountTypes>
    {
        private readonly BudgetApplicationContext _context;

        public BankAccountTypeDataAccess(BudgetApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList> GetAllAsync()
        {
            return await _context.BankAccountTypes.ToListAsync();
        }

        public async Task<BankAccountTypes> GetByIdAsync(int bankAccountTypeId)
        {
            return await _context.BankAccountTypes.Where(b => b.BankAccountTypeId == bankAccountTypeId).FirstOrDefaultAsync();
        }
    }
}
