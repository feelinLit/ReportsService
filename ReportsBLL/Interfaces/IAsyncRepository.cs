using System.Linq.Expressions;
using ReportsBLL.Entities;

namespace ReportsBLL.Interfaces;

public interface IAsyncRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<bool> DeleteAsync(T entity);

    Task<T> GetAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
}