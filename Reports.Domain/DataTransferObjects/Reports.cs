using System.ComponentModel.DataAnnotations;
using Reports.Domain.Interfaces;
using Reports.Domain.Models.Reports;

namespace Reports.Domain.DataTransferObjects;

public record ReportViewModel(
        ulong Id,
        string Description,
        ulong EmployeeId,
        bool IsCompleted,
        IEnumerable<ProblemViewModel> Problems)
    : IViewModel<Report>;

public record AddReportDto(
        [StringLength(100)] string Description,
        ulong EmployeeId)
    : IDataTransferObject<Report>;