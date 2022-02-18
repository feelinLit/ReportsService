using ReportsBLL.Entities;

namespace ReportsBLL.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}