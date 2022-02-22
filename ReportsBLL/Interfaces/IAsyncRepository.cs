using System.Linq.Expressions;
using ReportsBLL.Models;

namespace ReportsBLL.Interfaces;

public interface IAsyncRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task<bool> DeleteAsync(T entity);

    Task<T?> GetAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
}