using System.ComponentModel.DataAnnotations;
using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.DataTransferObjects.Reports;

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