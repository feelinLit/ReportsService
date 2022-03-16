using Microsoft.EntityFrameworkCore;
using ReportsBLL.Interfaces;
using ReportsBLL.Models;
using ReportsDAL.Data.Repositories;

namespace ReportsDAL.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ReportsDbContext _dbContext;

    public UnitOfWork(ReportsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}