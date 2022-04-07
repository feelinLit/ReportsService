using ReportsBLL.DataTransferObjects.Reports;
using ReportsBLL.Services.Communication;

namespace ReportsBLL.Interfaces.Services;

public interface IReportService
{
    public Task<Response<ReportViewModel>> GetAsync(ulong id);
    public Task<Response<ReportViewModel>> SaveAsync(AddReportDto addReportDto);
    public Task<Response<ReportViewModel>> UpdateAsync(ulong id, string description);
    public Task<Response<ReportViewModel>> AddProblem(ulong reportId, ulong problemId);
    public Task<Response<ReportViewModel>> CompleteAsync(ulong reportId);
    public Task<Response<List<ReportViewModel>>> GetAllFromSubordinatesAsync(ulong supervisorId);
}