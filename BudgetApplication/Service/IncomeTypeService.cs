using BudgetApplication.DataAccess;
using BudgetApplication.Models;
using System.Collections;

namespace BudgetApplication.Service
{
    public class IncomeTypeService : ITypeService<IncomeTypes>
    {
        private readonly ITypeDataAccess<IncomeTypes> _incomeTypesDataAccess;

        public IncomeTypeService(ITypeDataAccess<IncomeTypes> incomeTypesDataAccess)
        {
            _incomeTypesDataAccess = incomeTypesDataAccess;
        }

        public async Task<IList> GetAllAsync()
        {
            return await _incomeTypesDataAccess.GetAllAsync();
        }

        public async Task<IncomeTypes> GetByIdAsync(int incomeTypeId)
        {
            return await _incomeTypesDataAccess.GetByIdAsync(incomeTypeId);
        }
    }
}
