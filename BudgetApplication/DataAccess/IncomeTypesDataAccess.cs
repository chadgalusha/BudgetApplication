using BudgetApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplication.DataAccess
{
    public class IncomeTypesDataAccess
    {
        private readonly BudgetApplicationContext _context;

        public IncomeTypesDataAccess(BudgetApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<IncomeTypes>> GetIncomeTypesAsync()
        {
            return await _context.IncomeTypes.ToListAsync();
        }

        public async Task<IncomeTypes?> GetIncomeTypeByIdAsync(int incomeTypeId)
        {
            return await _context.IncomeTypes.Where(x => x.IncomeTypeId == incomeTypeId).FirstOrDefaultAsync();
        }
    }
}
