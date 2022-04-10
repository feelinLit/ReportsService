namespace Reports.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}