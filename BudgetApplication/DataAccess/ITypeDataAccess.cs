using System.Collections;

namespace BudgetApplication.DataAccess
{
    public interface ITypeDataAccess<T>
    {
        Task<IList> GetAllAsync();

        Task<T> GetByIdAsync(int id);
    }
}
