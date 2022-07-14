using BudgetApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BudgetApplication.DataAccess
{
    public class PaymentFrequencyTypesDataAccess : ITypeDataAccess<PaymentFrequencyTypes>
    {
        private readonly BudgetApplicationContext _context;

        public PaymentFrequencyTypesDataAccess(BudgetApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList> GetAllAsync()
        {
            return await _context.PaymentFrequencyTypes.ToListAsync();
        }

        public async Task<PaymentFrequencyTypes> GetByIdAsync(int paymentFrequencyTypeId)
        {
            return await _context.PaymentFrequencyTypes.Where(p => p.PaymentFrequencyTypeId == paymentFrequencyTypeId).FirstOrDefaultAsync();
        }
    }
}
