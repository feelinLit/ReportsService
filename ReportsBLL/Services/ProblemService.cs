using AutoMapper;
using ReportsBLL.DataTransferObjects;
using ReportsBLL.DataTransferObjects.Comments;
using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Interfaces;
using ReportsBLL.Interfaces.Services;
using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;
using ReportsBLL.Services.Communication;

namespace ReportsBLL.Services;

public class ProblemService : BaseService<Employee>, IProblemService
{
    public ProblemService(IRepository<Employee> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }

    public async Task<Response<List<ProblemViewModel>>> GetAllAsync()
    {
        var employees = await Repository.GetListAsync(e => true);
        var problems = employees.SelectMany(employee => employee.Problems).ToList();
        return new Response<List<ProblemViewModel>>(Mapper.Map<List<Problem>, List<ProblemViewModel>>(problems));
    }

    public async Task<Response<ProblemViewModel>> GetAsync(ulong id)
    {
        var employee = await FindAssignedEmployee(id);
        if (employee is null) return new Response<ProblemViewModel>($"Problem wasn't found: id = {id}");

        var problem = employee.Problems.First(p => p.Id == id);

        return new Response<ProblemViewModel>(Mapper.Map<Problem, ProblemViewModel>(problem));
    }

    public async Task<Response<ProblemViewModel>> SaveAsync(AddProblemDto addProblemDto)
    {
        var employee = await Repository.FindAsync(e => e.Id == addProblemDto.EmployeeId);
        if (employee is null)
            return new Response<ProblemViewModel>($"Assigned employee wasn't found: id = {addProblemDto.EmployeeId}");

        try
        {
            var problem = employee.AddProblem(addProblemDto.Description);
            await UnitOfWork.SaveChangesAsync();

            var problemDto = Mapper.Map<Problem, ProblemViewModel>(problem);
            return new Response<ProblemViewModel>(problemDto);
        }
        catch (Exception e)
        {
            return new Response<ProblemViewModel>($"An error occured while saving the problem: {e.Message}");
        }
    }

    public async Task<Response<ProblemViewModel>> UpdateAsync(ulong id, UpdateProblemDto updateProblemDto)
    {
        var employeeAssigned = await Repository.FindAsync(e => e.Problems.Any(p => p.Id == id));
        if (employeeAssigned is null) return new Response<ProblemViewModel>($"Problem wasn't found: id = {id}");

        var problem = employeeAssigned.Problems.FirstOrDefault(p => p.Id == id);
        if (problem is null)
            return new Response<ProblemViewModel>($"Employee:{employeeAssigned.Id} not assigned to the problem:{id}");

        if (employeeAssigned.Id != updateProblemDto.EmployeeId)
        {
            var employeeReassigned = await Repository.FindAsync(e => e.Id == updateProblemDto.EmployeeId);
            if (employeeReassigned is null)
                return new Response<ProblemViewModel>(
                    $"Reassigned employee wasn't found: id = {updateProblemDto.EmployeeId}");

            if (!employeeAssigned.TryRemoveProblem(problem))
                return new Response<ProblemViewModel>("Error occured while removing problem from assigned employee");

            employeeReassigned.AddProblem(problem); // TODO: try-catch
            employeeAssigned = employeeReassigned;
        }


        try
        {
            problem.Update(updateProblemDto.Description, employeeAssigned);
            await UnitOfWork.SaveChangesAsync();

            var problemDto = Mapper.Map<Problem, ProblemViewModel>(problem);
            return new Response<ProblemViewModel>(problemDto);
        }
        catch (Exception e)
        {
            return new Response<ProblemViewModel>($"An error occured while updating the problem: {e.Message}");
        }
    }

    public async Task<bool> DeleteAsync(ulong id)
    {
        var employee = await FindAssignedEmployee(id);
        if (employee is null) return false;

        var problem = employee.Problems.First(p => p.Id == id);

        try
        {
            var success = employee.TryRemoveProblem(problem);
            await UnitOfWork.SaveChangesAsync();
            return success;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<Response<ProblemViewModel>> CloseProblem(ulong id)
    {
        var employee = await FindAssignedEmployee(id);
        if (employee is null)
            return new Response<ProblemViewModel>("Assigned employee wasn't found");

        var problem = employee.Problems.First(p => p.Id == id);

        try
        {
            problem.CloseProblem();
            await UnitOfWork.SaveChangesAsync();

            var problemDto = Mapper.Map<Problem, ProblemViewModel>(problem);
            return new Response<ProblemViewModel>(problemDto);
        }
        catch (Exception e)
        {
            return new Response<ProblemViewModel>($"An error occured while closing the problem: {e.Message}");
        }
    }

    public async Task<Response<ProblemViewModel>> AddComment(ulong problemId, AddCommentDto addCommentDto)
    {
        var employee = await FindAssignedEmployee(problemId);
        if (employee is null)
            return new Response<ProblemViewModel>("Problem wasn't found");

        var problem = employee.Problems.First(p => p.Id == problemId);

        try
        {
            employee.AddComment(problem, addCommentDto.Content);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ProblemViewModel>(Mapper.Map<Problem, ProblemViewModel>(problem));
        }
        catch (Exception e)
        {
            return new Response<ProblemViewModel>($"An error occured while adding new comment: {e.Message}");
        }
    }

    private async Task<Employee?> FindAssignedEmployee(ulong problemId)
    {
        return await Repository.FindAsync(e => e.Problems.Any(p => p.Id == problemId));
    }
}