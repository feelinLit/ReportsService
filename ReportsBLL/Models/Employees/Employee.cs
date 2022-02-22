using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public class Employee : BaseEntity, IEmployee
{
    protected Employee(string username, int? supervisorId, IList<ISubordinate> subordinates)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username)); // TODO: Custom exceptions
        SupervisorId = supervisorId;
        Subordinates = subordinates ?? throw new ArgumentNullException(nameof(subordinates));
    }

    public string Username { get; set; }
    public IList<Problem> Problems { get; set; } = new List<Problem>();
    public ISupervisor? Supervisor { get; set; }
    public int? SupervisorId { get; set; }
    public IList<Report> Reports { get; set; } = new List<Report>();
    public IList<ISubordinate> Subordinates { get; set; }

    public void AddNewProblem(Problem problem)
    {
        throw new NotImplementedException();
    }

    public void UpdateProblem(Problem problem)
    {
        throw new NotImplementedException();
    }

    public virtual Report MakeReport(Report report)
    {
        throw new NotImplementedException();
    }
}