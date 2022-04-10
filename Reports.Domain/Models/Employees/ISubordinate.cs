using Reports.Domain.Models.Problems;
using Reports.Domain.Models.Reports;

namespace Reports.Domain.Models.Employees;

public interface ISubordinate : IPerson
{
    ISupervisor? Supervisor { get; set; }
    ulong? SupervisorId { get; }
    Report? Report { get; }
    IEnumerable<Problem> Problems { get; }
    Problem AddProblem(string description);
    void AddProblem(Problem problem);
    bool TryRemoveProblem(Problem problem);
}