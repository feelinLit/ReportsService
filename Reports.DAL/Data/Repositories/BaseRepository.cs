﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Reports.Domain.Interfaces;
using Reports.Domain.Models;

namespace Reports.DAL.Data.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot
{
    private readonly DbSet<T> _dbSet;

    protected BaseRepository(ReportsDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    protected DbSet<T> DbSet => _dbSet;

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public virtual Task<bool> DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public virtual async Task<T?> FindByIdAsync(ulong id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await DbSet.SingleOrDefaultAsync(expression);
    }

    public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression)
    {
        return await DbSet.Where(expression).ToListAsync();
    }
}