using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.DataTransferObjects.Reports;

public class ReportViewModel : IViewModel<Report>
{
    public ulong Id { get; set; }
    public string Description { get; set; }
    public ulong EmployeeId { get; set; }
    public bool IsCompleted { get; set; }
    public IEnumerable<ProblemViewModel> Problems { get; set; }
}