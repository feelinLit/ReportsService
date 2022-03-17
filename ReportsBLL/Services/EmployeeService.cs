using AutoMapper;
using ReportsBLL.DataTransferObjects;
using ReportsBLL.DataTransferObjects.Employees;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Employees;
using ReportsBLL.Services.Communication;

namespace ReportsBLL.Services;

public class EmployeeService : BaseService<Employee>
{
    public EmployeeService(IRepository<Employee> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }

    public async Task<Response<EmployeeDto>> GetAllAsync()
    {
        var employees = await Repository.GetListAsync(e => true);
        return new Response<EmployeeDto>(Mapper.Map<List<Employee>, List<EmployeeDto>>(employees));
    }

    public async Task<Response<EmployeeDto>> GetAsync(ulong id)
    {
        var employee = await Repository.FindAsync(e => e.Id == id);
        if (employee == null)
            return new Response<EmployeeDto>($"Employee wasn't found: id = {id}");

        return new Response<EmployeeDto>(Mapper.Map<Employee, EmployeeDto>(employee));
    }

    public async Task<Response<EmployeeDto>> SaveAsync(AddEmployeeDto addEmployeeDto)
    {
        var employee = Mapper.Map<AddEmployeeDto, Employee>(addEmployeeDto);

        try
        {
            await Repository.AddAsync(employee);
            await UnitOfWork.SaveChangesAsync();

            var employeeDto = Mapper.Map<Employee, EmployeeDto>(employee);
            return new Response<EmployeeDto>(employeeDto);
        }
        catch (Exception e)
        {
            return new Response<EmployeeDto>($"An error occured while saving the employee: {e.Message}");
        }
    }

    public async Task<Response<EmployeeDto>> UpdateAsync(ulong id, UpdateEmployeeDto updateEmployeeDto)
    {
        var employee = await Repository.FindAsync(e => e.Id == id);
        if (employee == null) return new Response<EmployeeDto>("Employee wasn't found");

        var updatedEmployee = Mapper.Map<UpdateEmployeeDto, Employee>(updateEmployeeDto);

        ISupervisor? updatedSupervisor = null;
        if (updateEmployeeDto.SupervisorId != null)
        {
            updatedSupervisor = await Repository.FindAsync(e => e.Id == updateEmployeeDto.SupervisorId);
            if (updatedSupervisor == null)
                return new Response<EmployeeDto>($"Supervisor with id={updateEmployeeDto.SupervisorId} doesn't exist");
        }

        try
        {
            updatedEmployee.Supervisor = updatedSupervisor;
            employee.Update(updatedEmployee);
            await Repository.UpdateAsync(employee);
            await UnitOfWork.SaveChangesAsync();

            return new Response<EmployeeDto>(Mapper.Map<Employee, EmployeeDto>(employee));
        }
        catch (Exception e)
        {
            return new Response<EmployeeDto>($"An error occured while updating the employee: {e.Message}");
        }
    }

    public async Task<bool> DeleteAsync(ulong id) // TODO: Async?
    {
        var employee = await Repository.FindAsync(e => e.Id == id);
        if (employee == null) return false;

        try
        {
            var success = await Repository.DeleteAsync(employee);
            await UnitOfWork.SaveChangesAsync();
            return success;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}