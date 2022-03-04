using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public class Employee : BaseEntity, IEmployee, ISubordinate, ISupervisor
{
    protected Employee()
    {
    }
    public Employee(string username, ISupervisor? supervisor)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Supervisor = supervisor;
    }

    public string Username { get; set; } // TODO: Might be problem with retrieving from db (check someEmployee.Supervisor)
    public ISupervisor? Supervisor { get; }
    public ulong? SupervisorId { get; set; }

    public IEnumerable<Problem> Problems { get; set; } = new HashSet<Problem>();

    public Report? Report { get; set; }
    public IEnumerable<ISubordinate> Subordinates { get; } = new HashSet<ISubordinate>();

    public void AddNewProblem(Problem problem)
    {
        throw new NotImplementedException();
    }

    public void CommentProblem(Problem problem)
    {
        throw new NotImplementedException();
    }

    public virtual Report MakeReport(Report report)
    {
        throw new NotImplementedException();
    }
}