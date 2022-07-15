using BudgetApplication.Models;
using BudgetApplication.Utilities;
using BudgetApplication.ViewModels;
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
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {
                Log.Error("Error, income not created: {errormessage}", e.Message);
                ExceptionsUtility.LogInnerExceptionMessageIfExists(e);
                return -1;
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
                ExceptionsUtility.LogInnerExceptionMessageIfExists(e);
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
                ExceptionsUtility.LogInnerExceptionMessageIfExists(e);
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

        public async Task<List<string>> GetListNamesAsync(string userId)
        {
            return await _context.Incomes.Where(a => a.UserId == userId).Select(a => a.IncomeName).ToListAsync();
        }

        public IList GetListIncomes(string userId)
        {
            List<IncomesViewModel> incomesList = (from i in _context.Incomes
                               join it in _context.IncomeTypes on i.IncomeTypeId equals it.IncomeTypeId
                               join p in _context.PaymentFrequencyTypes on i.PaymentFrequencyTypeId equals p.PaymentFrequencyTypeId
                               where i.UserId == userId
                               select new IncomesViewModel
                               {
                                   IncomeId = i.IncomeId,
                                   IncomeName = i.IncomeName,
                                   IncomeType = it.IncomeType,
                                   PaymentFrequency = p.PaymentFrequencyType
                               }).ToList();
            return incomesList;
        }
    }
}
