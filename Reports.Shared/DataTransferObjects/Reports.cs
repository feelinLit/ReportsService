using System.ComponentModel.DataAnnotations;

namespace Reports.Shared.DataTransferObjects;

public record ReportViewModel(
    ulong Id,
    string Description,
    ulong EmployeeId,
    bool IsCompleted,
    IEnumerable<ProblemViewModel> Problems);

public record AddReportDto(
        string Description,
        ulong EmployeeId);
public record UpdateReportDto(
        string Description);