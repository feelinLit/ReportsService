using AutoMapper;
using ReportsBLL.DataTransferObjects;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Employees;
using ReportsBLL.Services.Communication;
using ReportsBLL.Tools;

namespace ReportsBLL.Services;

public class EmployeeService : BaseService
{
    public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
    }

    public async Task<Response<EmployeeDto>> Get(ulong id)
    {
        var employee = await UnitOfWork.GetAsyncRepository<Employee>().GetAsync(e => e.Id == id);
        if (employee == null)
            return new Response<EmployeeDto>("Employee wasn't found");

        return new Response<EmployeeDto>(Mapper.Map<Employee, EmployeeDto>(employee));
    }
}