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
}