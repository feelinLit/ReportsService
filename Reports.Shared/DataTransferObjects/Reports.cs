using System.ComponentModel.DataAnnotations;

namespace Reports.Shared.DataTransferObjects;

public record ReportViewModel(
    ulong Id,
    string Description,
    ulong EmployeeId,
    bool IsCompleted,
    IEnumerable<ProblemViewModel> Problems);

public record AddReportDto(
        [StringLength(100)] string Description,
        ulong EmployeeId);