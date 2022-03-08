using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReportsBLL.Interfaces;
using ReportsBLL.Models;

namespace ReportsDAL.Data.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot
{
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public Task<bool> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(expression).ToListAsync();
    }
}