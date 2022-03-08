using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;
using ReportsBLL.Tools;

namespace ReportsBLL.Models.Reports;

public class Report : BaseEntity
{
    private readonly HashSet<Problem> _problems = new();

    protected Report()
    {
    }

    public Report(string description, ISubordinate employee)
    {
        Description = description;
        Employee = employee ?? throw new DomainException(
            "Employee in report can't be null!",
            new ArgumentNullException(nameof(employee)));
    }

    public IEnumerable<Problem> Problems => _problems;

    public string Description { get; }
    public bool IsCompleted { get; set; } = false;
    public IPerson Employee { get; }

    public void AddProblem(Problem problem) // TODO: Validation, change state
    {
        _problems.Add(problem);
    }
}