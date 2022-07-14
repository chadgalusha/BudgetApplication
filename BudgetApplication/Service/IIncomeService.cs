using BudgetApplication.Models;
using System.Collections;

namespace BudgetApplication.Service
{
    public interface IIncomeService
    {
        Task<int> CreateIncomeAsync(string incomeName, string userId, int incomeTypeId, int paymentFrequencyId);
        Task<int> DeleteIncomeAsync(string userId, int incomeId);
        Task<int> EditIncomeAsync(int incomeId, string incomeName, string userId, int incomeTypeId, int paymentFrequencyId);
        Task<Incomes> GetUserIncomeByIdAsync(string userId, int incomeId);
        Task<IList> GetUserIncomesAsync(string userId);
    }
}