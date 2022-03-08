using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public interface ISubordinate : IPerson
{
    public ISupervisor? Supervisor { get; }
    public ulong? SupervisorId { get; } // TODO: Shadow property or field
    public Report? Report { get; }
    public IEnumerable<Problem> Problems { get; }
    public void AddProblem(string description);
}