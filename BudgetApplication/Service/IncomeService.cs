using BudgetApplication.DataAccess;
using BudgetApplication.Models;
using Serilog;
using System.Collections;

namespace BudgetApplication.Service
{
    public class IncomeService : IIncomeService
    {
        private readonly IDataAccess<Incomes> _incomeDataAccess;

        public IncomeService(IDataAccess<Incomes> incomeDataAccess)
        {
            _incomeDataAccess = incomeDataAccess;
        }

        public async Task<IList> GetUserIncomesAsync(string userId)
        {
            return await _incomeDataAccess.GetAllByUserIdAsync(userId);
        }

        public async Task<Incomes> GetUserIncomeByIdAsync(string userId, int incomeId)
        {
            if (IsUserOwnerOfIncome(userId, incomeId) == false)
            {
                Log.Information("Wrong user [{userId}] tried to access income [{incomeId}]", userId, incomeId);
                return new Incomes();
            }

            List<Incomes> userIncomes = (List<Incomes>)await GetUserIncomesAsync(userId);
            return userIncomes.FirstOrDefault(i => i.IncomeId == incomeId) ?? new Incomes();
        }

        public async Task<int> EditIncomeAsync(int incomeId, string incomeName, string userId, int incomeTypeId, int paymentFrequencyId)
        {
            if (IsUserOwnerOfIncome(userId, incomeId) == false)
            {
                Log.Information("Wrong user [{userId}] tried to edit income [{incomeId}]", userId, incomeId);
                return -1;
            }

            var userIncome = await _incomeDataAccess.GetByIdAsync(incomeId);

            userIncome.IncomeName = incomeName;
            userIncome.IncomeTypeId = incomeTypeId;
            userIncome.PaymentFrequencyTypeId = paymentFrequencyId;

            return await _incomeDataAccess.EditAsync(userIncome);
        }

        public async Task<int> CreateIncomeAsync(string incomeName, string userId, int incomeTypeId, int paymentFrequencyId)
        {
            Incomes newIncome = new()
            {
                IncomeName = incomeName,
                UserId = userId,
                IncomeTypeId = incomeTypeId,
                PaymentFrequencyTypeId = paymentFrequencyId
            };

            return await _incomeDataAccess.CreateAsync(newIncome);
        }

        public async Task<int> DeleteIncomeAsync(string userId, int incomeId)
        {
            if (IsUserOwnerOfIncome(userId, incomeId) == false)
            {
                Log.Information("Wrong user [{userId}] tried to delete income [{incomeId}]", userId, incomeId);
                return -1;
            }

            return await _incomeDataAccess.DeleteByIdAsync(incomeId);
        }

        #region Private Methods

        private bool IsUserOwnerOfIncome(string userId, int incomeId)
        {
            var income = _incomeDataAccess.GetByIdAsync(incomeId).Result;

            if (income.UserId == userId)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
