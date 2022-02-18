using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReportsBLL.Entities;
using ReportsBLL.Interfaces;

namespace ReportsDAL.Data.Repositories;

public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;

    protected RepositoryBase(DbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }
}