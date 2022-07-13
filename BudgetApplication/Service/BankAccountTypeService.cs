using BudgetApplication.DataAccess;
using BudgetApplication.Models;
using System.Collections;

namespace BudgetApplication.Service
{
    public class BankAccountTypeService : ITypeService<BankAccountTypes>
    {
        private readonly ITypeDataAccess<BankAccountTypes> _bankAccountTypeDataAccess;

        public BankAccountTypeService(ITypeDataAccess<BankAccountTypes> bankAccountTypeDataAccess)
        {
            _bankAccountTypeDataAccess = bankAccountTypeDataAccess;
        }

        public async Task<IList> GetAllAsync()
        {
            return await _bankAccountTypeDataAccess.GetAllAsync();
        }
    }
}
