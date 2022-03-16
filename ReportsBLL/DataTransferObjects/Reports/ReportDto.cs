using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Interfaces;

namespace ReportsBLL.DataTransferObjects.Reports;

public class ReportDto : IViewModel
{
    public ulong Id { get; set; }
    public string Description { get; set; }
    public ulong EmployeeId { get; set; }
    public bool IsCompleted { get; set; }
    public IEnumerable<ProblemDto> Problems { get; set; }
}