using AutoMapper;
using ReportsBLL.Interfaces;

namespace ReportsBLL.Services;

public abstract class BaseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    protected internal IUnitOfWork UnitOfWork => _unitOfWork;
    protected internal IMapper Mapper => _mapper;
}