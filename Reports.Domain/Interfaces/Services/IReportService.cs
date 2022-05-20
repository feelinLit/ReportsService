using Reports.Domain.Services.Communication;
using Reports.Shared.DataTransferObjects;

namespace Reports.Domain.Interfaces.Services;

public interface IReportService
{
    Task<Response<List<ReportViewModel>>> GetAllAsync();
    Task<Response<ReportViewModel>> GetAsync(ulong id);
    Task<Response<ReportViewModel>> SaveAsync(AddReportDto addReportDto);
    Task<Response<ReportViewModel>> UpdateAsync(ulong id, string description);
    Task<Response<ReportViewModel>> AddProblem(ulong reportId, ulong problemId);
    Task<Response<ReportViewModel>> CompleteAsync(ulong reportId);
    Task<Response<List<ReportViewModel>>> GetAllFromSubordinatesAsync(ulong supervisorId);
}