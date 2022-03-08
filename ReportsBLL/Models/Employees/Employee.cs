using ReportsBLL.Interfaces;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;
using ReportsBLL.Tools;

namespace ReportsBLL.Models.Employees;

// TODO: How to add problem to a report
public class Employee : BaseEntity, IAggregateRoot, IEmployee, ISubordinate, ISupervisor
{
    private HashSet<Problem> _problems = new HashSet<Problem>(); // TODO: Remember about .Include and that article
    private HashSet<ISubordinate> _subordinates = new HashSet<ISubordinate>();

    protected Employee()
    {
    }

    public Employee(string username, ISupervisor? supervisor)
    {
        if (string.IsNullOrEmpty(username))
            throw new DomainException(
                "Employee's username can't be null or empty!",
                new ArgumentNullException(nameof(username)));

        Username = username;
        Supervisor = supervisor;
    }

    public string Username { get; } // Value Object "Username"

    public ISupervisor? Supervisor { get; } // TODO: Might be a problem with retrieving from db
    public ulong? SupervisorId { get; }

    public IEnumerable<Problem> Problems => _problems;

    public Report? Report { get; private set; }

    public IEnumerable<ISubordinate> Subordinates => _subordinates;

    public void AddProblem(string description)
    {
        if (Problems.Any(p => p.Description == description))
            throw new DomainException("Problem with given description is already assigned to an employee");

        _problems.Add(new Problem(description, this));
    }

    public void AddSubordinate(ISubordinate subordinate)
    {
        if (Subordinates.Any(p => p.Equals(subordinate)))
            throw new DomainException("Adding subordinate already exists");

        _subordinates.Add(subordinate);
    }

    public void AddSubordinate(string username) => _subordinates.Add(new Employee(username, this));

    public void AddComment(Problem problem, string content)
    {
        throw new NotImplementedException();
    }

    public void CreateReport(string description) => Report = new Report(description, this);
}