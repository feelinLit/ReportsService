using AutoMapper;
using Reports.Domain.Interfaces;
using Reports.Domain.Models;

namespace Reports.Domain.Services;

public abstract class BaseService<T> where T : BaseEntity, IAggregateRoot
{
    private readonly IRepository<T> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    protected BaseService(IRepository<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    protected internal IRepository<T> Repository => _repository;
    protected internal IUnitOfWork UnitOfWork => _unitOfWork;
    protected internal IMapper Mapper => _mapper;
}