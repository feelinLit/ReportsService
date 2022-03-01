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

    public IList<Problem> Problems { get; set; }

    // public IList<Report> Reports { get; set; } = new List<Report>();
    // public IList<Problem> Problems { get; set; } = new List<Problem>();
    public IList<ISubordinate> Subordinates { get; } = new List<ISubordinate>();

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