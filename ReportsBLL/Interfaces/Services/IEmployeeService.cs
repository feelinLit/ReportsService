using ReportsBLL.DataTransferObjects.Employees;
using ReportsBLL.Services.Communication;

namespace ReportsBLL.Interfaces.Services;

public interface IEmployeeService
{
    public Task<Response<List<EmployeeViewModel>>> GetAllAsync();
    public Task<Response<EmployeeViewModel>> GetAsync(ulong id);
    public Task<Response<EmployeeViewModel>> SaveAsync(AddEmployeeDto addEmployeeDto);
    public Task<Response<EmployeeViewModel>> UpdateAsync(ulong id, UpdateEmployeeDto updateEmployeeDto);
    public Task<bool> DeleteAsync(ulong id);

}