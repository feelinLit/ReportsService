using ReportsBLL.Models.Reports;
using ReportsBLL.Tools.Exceptions;

namespace ReportsBLL.Models.Employees;

public class TeamLead : Employee
{
    protected TeamLead()
    {
    }

    public TeamLead(string username, ISupervisor? supervisor)
        : base(username, supervisor)
    {
    }

    public override ISupervisor? Supervisor
    {
        get => _supervisor;
        set => _supervisor = value == null ? value : throw new DomainException("TeamLead can't have supervisor!");
    }

    public override Report AddReport(string description) // TODO: Add related problems while closing, add form sub-sub
    {
        var report = base.AddReport(description);

        foreach (var problem in Subordinates.Where(s => s.Report is not null).SelectMany(s => s.Report.Problems))
        {
            report.AddProblem(problem);
        }

        return report;
    }
}