using ReportsBLL.Interfaces;

namespace ReportsAPI.Services;

public abstract class BaseService
{
    protected BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected internal IUnitOfWork UnitOfWork { get; set; }
}