using AutoMapper;
using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.DataTransferObjects.Reports;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;
using ReportsBLL.Services.Communication;

namespace ReportsBLL.Services;

public class ReportService : BaseService<Employee>
{
    public ReportService(IRepository<Employee> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }

    public async Task<Response<ReportDto>> GetAsync(ulong id)
    {
        var employee = await Repository.FindAsync(e => e.Report != null && e.Report.Id == id);
        if (employee is null)
            return new Response<ReportDto>($"Report wasn't found");

        var report = employee.Report!;
        return new Response<ReportDto>(Mapper.Map<Report, ReportDto>(report));
    }

    public async Task<Response<ReportDto>> SaveAsync(AddReportDto addReportDto)
    {
        var employee = await Repository.FindAsync(e => e.Id == addReportDto.EmployeeId);
        if (employee is null)
            return new Response<ReportDto>($"Employee wasn't found: id = {addReportDto.EmployeeId}");

        try
        {
            var report = employee.AddReport(addReportDto.Description);
            await UnitOfWork.SaveChangesAsync();

            var reportDto = Mapper.Map<Report, ReportDto>(report);
            return new Response<ReportDto>(reportDto);
        }
        catch (Exception e)
        {
            return new Response<ReportDto>($"An error occured while saving the report: {e.Message}");
        }
    }

    public async Task<Response<ReportDto>> UpdateAsync(ulong id, string description)
    {
        var employee = await Repository.FindAsync(e => e.Report != null && e.Report.Id == id);
        if (employee is null)
            return new Response<ReportDto>($"Report wasn't found");

        var report = employee.Report;
        try
        {
            report.Description = description;
            await UnitOfWork.SaveChangesAsync();

            var reportDto = Mapper.Map<Report, ReportDto>(report);
            return new Response<ReportDto>(reportDto);
        }
        catch (Exception e)
        {
            return new Response<ReportDto>($"An error occured while updating the report: {e.Message}");
        }
    }

    public async Task<Response<ReportDto>> AddProblem(ulong reportId, ulong problemId)
    {
        var employee = await Repository.FindAsync(e => e.Report != null && e.Report.Id == reportId);
        if (employee == null)
            return new Response<ReportDto>($"Report wasn't found");

        var report = employee.Report;
        var problem = employee.Problems.FirstOrDefault(p => p.Id == problemId);
        if (problem is null)
            return new Response<ReportDto>($"Can't add problem:{problemId} to the report:{reportId}");

        try
        {
            report!.AddProblem(problem);
            await UnitOfWork.SaveChangesAsync();

            var reportDto = Mapper.Map<Report, ReportDto>(report);
            return new Response<ReportDto>(reportDto);
        }
        catch (Exception e)
        {
            return new Response<ReportDto>($"An error occured while adding new problem to the report: {e.Message}");
        }
    }

    public async Task<Response<ReportDto>> CompleteAsync(ulong reportId)
    {
        var employee =
            await Repository.FindAsync(e => e.Report != null && e.Report.Id == reportId); // TODO: Find _report_
        if (employee == null)
            return new Response<ReportDto>($"Report wasn't found");

        var report = employee.Report!;
        try
        {
            report.IsCompleted = true;
            await UnitOfWork.SaveChangesAsync();

            var reportDto = Mapper.Map<Report, ReportDto>(report);
            return new Response<ReportDto>(reportDto);
        }
        catch (Exception e)
        {
            return new Response<ReportDto>($"An error occured while completing the report: {e.Message}");
        }
    }

    public async Task<Response<ReportDto>> GetAllFromSubordinatesAsync(ulong supervisorId)
    {
        var employee = await Repository.FindAsync(e => e.Id == supervisorId);
        if (employee is null)
            return new Response<ReportDto>("Employee wasn't found");
        List<Report> reports = employee.Subordinates
            .Select(s => s.Report)
            .Where(r => r is not null && r.IsCompleted)
            .ToList()!;
        return new Response<ReportDto>(Mapper.Map<List<Report>, List<ReportDto>>(reports));
    }
}