using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public interface ISubordinate : IPerson
{
    public ISupervisor? Supervisor { get; }
    public ulong? SupervisorId { get; }
    public Report? Report { get; }
    public IEnumerable<Problem> Problems { get; } // TODO: Probably HashSet is better
    public void AddNewProblem(Problem problem);

}