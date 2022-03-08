using ReportsBLL.Models;

namespace ReportsBLL.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    IRepository<T> GetAsyncRepository<T>() where T : BaseEntity, IAggregateRoot;
}