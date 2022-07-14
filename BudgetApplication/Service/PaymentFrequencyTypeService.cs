using BudgetApplication.DataAccess;
using BudgetApplication.Models;
using System.Collections;

namespace BudgetApplication.Service
{
    public class PaymentFrequencyTypeService : ITypeService<PaymentFrequencyTypes>
    {
        private readonly ITypeDataAccess<PaymentFrequencyTypes> _paymentFrequencyTypeDataAccess;

        public PaymentFrequencyTypeService(ITypeDataAccess<PaymentFrequencyTypes> paymentFrequencyTypeDataAccess)
        {
            _paymentFrequencyTypeDataAccess = paymentFrequencyTypeDataAccess;
        }

        public async Task<IList> GetAllAsync()
        {
            return await _paymentFrequencyTypeDataAccess.GetAllAsync();
        }

        public async Task<PaymentFrequencyTypes> GetByIdAsync(int paymentFrequencyTypeId)
        {
            return await _paymentFrequencyTypeDataAccess.GetByIdAsync(paymentFrequencyTypeId);
        }
    }
}
