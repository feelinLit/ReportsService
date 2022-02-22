using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public class TeamLead : Employee
{
    public TeamLead(string username, int? supervisorId, IList<ISubordinate> subordinates)
        : base(username, supervisorId, subordinates)
    {
    }

    public override Report MakeReport(Report report)
    {
        throw new NotImplementedException();
    }
}