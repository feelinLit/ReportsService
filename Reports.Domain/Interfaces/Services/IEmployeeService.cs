using Reports.Domain.Services.Communication;
using Reports.Shared.DataTransferObjects;

namespace Reports.Domain.Interfaces.Services;

public interface IEmployeeService
{
    public Task<Response<List<EmployeeViewModel>>> GetAllAsync();
    public Task<Response<EmployeeViewModel>> GetAsync(ulong id);
    public Task<Response<EmployeeViewModel>> SaveAsync(AddEmployeeDto addEmployeeDto);
    public Task<Response<EmployeeViewModel>> UpdateAsync(ulong id, UpdateEmployeeDto updateEmployeeDto);
    public Task<Response<EmployeeViewModel>> DeleteAsync(ulong id);
}