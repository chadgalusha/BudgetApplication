using BudgetApplication.DataAccess;
using BudgetApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplication.Service
{
    public class BankAccountTypeService
    {
        private readonly BudgetApplicationContext _context;
        private readonly BankAccountTypeDataAccess _bankAccountTypeDataAccess;

        public BankAccountTypeService(BudgetApplicationContext context, BankAccountTypeDataAccess bankAccountTypeDataAccess)
        {
            _context = context;
            _bankAccountTypeDataAccess = bankAccountTypeDataAccess;
        }

        public async Task<List<BankAccountTypes>> GetBankAccountTypesAsync()
        {
            List<BankAccountTypes> bankAccountTypes = await _bankAccountTypeDataAccess.GetBankAccountTypesAsync();

            List<BankAccountTypes> bankAccountTypesList = new();

            foreach (var type in bankAccountTypes)
            {
                BankAccountTypes b = new()
                {
                    BankAccountTypeId = type.BankAccountTypeId,
                    BankAccountType = type.BankAccountType
                };
                bankAccountTypesList.Add(b);
            }

            return bankAccountTypesList;
        }

        public DbSet<BankAccountTypes> GetBankAccountTypes()
        {
            return _bankAccountTypeDataAccess.GetBankAccountTypes();
        }
    }
}
