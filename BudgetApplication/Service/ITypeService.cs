using System.Collections;

namespace BudgetApplication.Service
{
    public interface ITypeService<T>
    {
        Task<IList> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
