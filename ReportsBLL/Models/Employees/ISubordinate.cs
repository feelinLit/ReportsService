using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public interface ISubordinate : IPerson
{
    ISupervisor? Supervisor { get; set; }
    ulong? SupervisorId { get; } // TODO: Shadow property or field
    Report? Report { get; }
    IEnumerable<Problem> Problems { get; }
    Problem AddProblem(string description);
    void AddProblem(Problem problem);
    bool TryRemoveProblem(Problem problem);
}