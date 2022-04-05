using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Interfaces;

namespace ReportsBLL.DataTransferObjects.Employees;

public class EmployeeViewModel : IViewModel
{
    public ulong Id { get; set; }
    public string Username { get; set; }
    public ulong? SupervisorId { get; set; }
    public IEnumerable<ProblemViewModel> Problems { get; set; }
}