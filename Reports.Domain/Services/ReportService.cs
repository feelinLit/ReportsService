﻿using AutoMapper;
using Reports.Domain.Interfaces;
using Reports.Domain.Interfaces.Services;
using Reports.Domain.Models.Employees;
using Reports.Domain.Models.Reports;
using Reports.Domain.Services.Communication;
using Reports.Shared.DataTransferObjects;

namespace Reports.Domain.Services;

public class ReportService : BaseService<Employee>, IReportService
{
    public ReportService(IRepository<Employee> repository, IUnitOfWork unitOfWork, IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }

    public async Task<Response<List<ReportViewModel>>> GetAllAsync()
    {
        var employees = await Repository.GetListAsync(e => e.Report != null);
        var reports = employees.Select(employee => employee.Report!).ToList();
        return new Response<List<ReportViewModel>>(Mapper.Map<List<Report>, List<ReportViewModel>>(reports));
    }

    public async Task<Response<ReportViewModel>> GetAsync(ulong id)
    {
        var employee = await Repository.FindAsync(e => e.Report != null && e.Report.Id == id);
        if (employee is null)
            return new Response<ReportViewModel>("Report wasn't found");

        var report = employee.Report!;
        return new Response<ReportViewModel>(Mapper.Map<Report, ReportViewModel>(report));
    }

    public async Task<Response<ReportViewModel>> SaveAsync(AddReportDto addReportDto)
    {
        var employee = await Repository.FindByIdAsync(addReportDto.EmployeeId);
        if (employee is null)
            return new Response<ReportViewModel>($"Employee wasn't found: id = {addReportDto.EmployeeId}");

        try
        {
            var report = employee.AddReport(addReportDto.Description);
            await UnitOfWork.SaveChangesAsync();

            var reportDto = Mapper.Map<Report, ReportViewModel>(report);
            return new Response<ReportViewModel>(reportDto);
        }
        catch (Exception e)
        {
            return new Response<ReportViewModel>($"An error occurred while saving the report: {e.Message}");
        }
    }

    public async Task<Response<ReportViewModel>> UpdateAsync(ulong id, string description)
    {
        var employee = await Repository.FindAsync(e => e.Report != null && e.Report.Id == id);
        if (employee is null)
            return new Response<ReportViewModel>("Report wasn't found");

        var report = employee.Report;
        try
        {
            report.Description = description;
            await UnitOfWork.SaveChangesAsync();

            var reportDto = Mapper.Map<Report, ReportViewModel>(report);
            return new Response<ReportViewModel>(reportDto);
        }
        catch (Exception e)
        {
            return new Response<ReportViewModel>($"An error occurred while updating the report: {e.Message}");
        }
    }

    public async Task<Response<ReportViewModel>> AddProblem(ulong reportId, ulong problemId)
    {
        var employee = await Repository.FindAsync(e => e.Report != null && e.Report.Id == reportId);
        if (employee == null)
            return new Response<ReportViewModel>("Report wasn't found");

        var report = employee.Report;
        var problem = employee.Problems.FirstOrDefault(p => p.Id == problemId);
        if (problem is null)
            return new Response<ReportViewModel>($"Can't add problem:{problemId} to the report:{reportId}");

        try
        {
            report!.AddProblem(problem);
            await UnitOfWork.SaveChangesAsync();

            var reportDto = Mapper.Map<Report, ReportViewModel>(report);
            return new Response<ReportViewModel>(reportDto);
        }
        catch (Exception e)
        {
            return new Response<ReportViewModel>($"An error occurred while adding new problem to the report: {e.Message}");
        }
    }

    public async Task<Response<ReportViewModel>> CompleteAsync(ulong reportId)
    {
        var employee = await Repository.FindAsync(e => e.Report != null && e.Report.Id == reportId);
        if (employee == null)
            return new Response<ReportViewModel>("Report wasn't found");

        var report = employee.Report!;
        try
        {
            report.IsCompleted = true;
            await UnitOfWork.SaveChangesAsync();

            var reportDto = Mapper.Map<Report, ReportViewModel>(report);
            return new Response<ReportViewModel>(reportDto);
        }
        catch (Exception e)
        {
            return new Response<ReportViewModel>($"An error occurred while completing the report: {e.Message}");
        }
    }

    public async Task<Response<List<ReportViewModel>>> GetAllFromSubordinatesAsync(ulong supervisorId)
    {
        var employee = await Repository.FindByIdAsync(supervisorId);
        if (employee is null)
            return new Response<List<ReportViewModel>>("Employee wasn't found");
        List<Report> reports = employee.Subordinates
            .Select(s => s.Report)
            .Where(r => r is not null && r.IsCompleted)
            .ToList()!;
        return new Response<List<ReportViewModel>>(Mapper.Map<List<Report>, List<ReportViewModel>>(reports));
    }
}