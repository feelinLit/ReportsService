using ReportsBLL.Models.Reports;

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

    public override Report AddReport(string description)
    {
        var report = base.AddReport(description);

        foreach (var problem in Subordinates.Select(s => s.Report).SelectMany(r => r.Problems))
        {
            report.AddProblem(problem);
        }

        return report;
    }
}