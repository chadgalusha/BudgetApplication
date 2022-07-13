using System.Collections;

namespace BudgetApplication.DataAccess
{
    public interface IDataAccess<T>
    {
        List<T> GetAll();
        Task<IList> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> EditByIdAsync(T entity);
        Task<T> CreateAsync(T entity);
        Task<T> DeleteByIdAsync(int id);
    }
}
