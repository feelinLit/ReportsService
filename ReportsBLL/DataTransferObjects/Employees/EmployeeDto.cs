using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Interfaces;

namespace ReportsBLL.DataTransferObjects.Employees;

public class EmployeeDto : IViewModel
{
    public ulong Id { get; set; }
    public string Username { get; set; }
    public ulong? SupervisorId { get; set; }
    public IEnumerable<ProblemDto> Problems { get; set; }
}