using BudgetApplication.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections;

namespace BudgetApplication.DataAccess
{
    public class IncomesDataAccess : IDataAccess<Incomes>
    {
        private readonly BudgetApplicationContext _context;

        public IncomesDataAccess(BudgetApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Incomes newIncome)
        {
            try
            {
                _context.Incomes.Add(newIncome);
                var result = await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {
                Log.Error("Error, income not created: {errormessage}", e.Message);
                return 0;
            }
        }

        public async Task<int> DeleteByIdAsync(int incomeId)
        {
            try
            {
                Incomes income = await GetByIdAsync(incomeId);
                _context.Incomes.Remove(income);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {
                Log.Error("Error, income not deleted: {errormessage}", e.Message);
                return 0;
            }
        }

        public async Task<int> EditAsync(Incomes income)
        {
            try
            {
                _context.Incomes.Update(income);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {
                Log.Error("Error, income not updated: {errormessage}", e.Message);
                return 0;
            }
        }

        public async Task<IList> GetAllByUserIdAsync(string userId)
        {
            return await _context.Incomes.Where(i => i.UserId == userId).ToListAsync();
        }

        public async Task<Incomes> GetByIdAsync(int incomeId)
        {
            return await _context.Incomes.Where(i => i.IncomeId == incomeId).FirstOrDefaultAsync() ?? new Incomes();
        }
    }
}
