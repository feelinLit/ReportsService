using ReportsBLL.DataTransferObjects.Problems;
using ReportsBLL.Interfaces;
using ReportsBLL.Models.Employees;

namespace ReportsBLL.DataTransferObjects.Employees;

public class EmployeeViewModel : IViewModel<Employee>
{
    public ulong Id { get; set; }
    public string Username { get; set; }
    public ulong? SupervisorId { get; set; }
    public IEnumerable<ProblemViewModel> Problems { get; set; }
}