using Reports.Domain.Interfaces;

namespace Reports.DAL.Data;

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