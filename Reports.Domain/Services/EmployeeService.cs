using AutoMapper;
using Reports.Domain.Interfaces;
using Reports.Domain.Interfaces.Services;
using Reports.Domain.Models.Employees;
using Reports.Domain.Services.Communication;
using Reports.Shared.DataTransferObjects;

namespace Reports.Domain.Services;

public class EmployeeService : BaseService<Employee>, IEmployeeService
{
    public EmployeeService(IRepository<Employee> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }

    public async Task<Response<List<EmployeeViewModel>>> GetAllAsync()
    {
        var employees = await Repository.GetListAsync(e => true);
        return new Response<List<EmployeeViewModel>>(Mapper.Map<List<Employee>, List<EmployeeViewModel>>(employees));
    }

    public async Task<Response<EmployeeViewModel>> GetAsync(ulong id)
    {
        var employee = await Repository.FindByIdAsync(id);
        if (employee == null)
            return new Response<EmployeeViewModel>($"Employee wasn't found: id = {id}");

        return new Response<EmployeeViewModel>(Mapper.Map<Employee, EmployeeViewModel>(employee));
    }

    public async Task<Response<EmployeeViewModel>> SaveAsync(AddEmployeeDto addEmployeeDto)
    {
        var employee = Mapper.Map<AddEmployeeDto, Employee>(addEmployeeDto);

        try
        {
            await Repository.AddAsync(employee);
            await UnitOfWork.SaveChangesAsync();

            var employeeDto = Mapper.Map<Employee, EmployeeViewModel>(employee);
            return new Response<EmployeeViewModel>(employeeDto);
        }
        catch (Exception e)
        {
            return new Response<EmployeeViewModel>($"An error occured while saving the employee: {e.Message}");
        }
    }

    public async Task<Response<EmployeeViewModel>> UpdateAsync(ulong id, UpdateEmployeeDto updateEmployeeDto)
    {
        var employee = await Repository.FindByIdAsync(id);
        if (employee == null) return new Response<EmployeeViewModel>("Employee wasn't found");

        var updatedEmployee = Mapper.Map<UpdateEmployeeDto, Employee>(updateEmployeeDto);

        ISupervisor? updatedSupervisor = null;
        if (updateEmployeeDto.SupervisorId != null)
        {
            updatedSupervisor = await Repository.FindAsync(e => e.Id == updateEmployeeDto.SupervisorId);
            if (updatedSupervisor == null)
                return new Response<EmployeeViewModel>($"Supervisor with id={updateEmployeeDto.SupervisorId} doesn't exist");
        }

        try
        {
            updatedEmployee.Supervisor = updatedSupervisor;
            employee.Update(updatedEmployee);
            await Repository.UpdateAsync(employee);
            await UnitOfWork.SaveChangesAsync();

            return new Response<EmployeeViewModel>(Mapper.Map<Employee, EmployeeViewModel>(employee));
        }
        catch (Exception e)
        {
            return new Response<EmployeeViewModel>($"An error occured while updating the employee: {e.Message}");
        }
    }

    public async Task<Response<EmployeeViewModel>> DeleteAsync(ulong id)
    {
        var employee = await Repository.FindByIdAsync(id);
        if (employee == null) return new Response<EmployeeViewModel>("Employee wasn't found");

        try
        {
            var success = await Repository.DeleteAsync(employee);
            await UnitOfWork.SaveChangesAsync();
            return new Response<EmployeeViewModel>(Mapper.Map<Employee, EmployeeViewModel>(employee));
        }
        catch (Exception e)
        {
            return new Response<EmployeeViewModel>($"An error occurred while deleting the employee: {e.Message}");
        }
    }
}