using System.Linq.Expressions;
using Reports.Domain.Models;

namespace Reports.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity, IAggregateRoot
{
    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task<bool> DeleteAsync(T entity);

    Task<T?> FindByIdAsync(ulong id);
    Task<T?> FindAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression);
}