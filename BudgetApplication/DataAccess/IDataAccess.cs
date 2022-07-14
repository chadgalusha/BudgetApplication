using System.Collections;

namespace BudgetApplication.DataAccess
{
    public interface IDataAccess<T>
    {
        Task<IList> GetAllByUserIdAsync(string userId);
        Task<T> GetByIdAsync(int id);
        Task<int> EditAsync(T entity);
        Task<int> CreateAsync(T entity);
        Task<int> DeleteByIdAsync(int id);
    }
}
