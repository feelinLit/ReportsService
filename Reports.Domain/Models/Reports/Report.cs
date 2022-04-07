using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;
using ReportsBLL.Tools;
using ReportsBLL.Tools.Exceptions;

namespace ReportsBLL.Models.Reports;

public class Report : BaseEntity
{
    private readonly List<Problem> _problems = new();
    private string _description;

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

    public string Description
    {
        get => _description;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Report's description can't be null or empty!");
            _description = value;
        }
    }

    public bool IsCompleted { get; set; }
    public IPerson Employee { get; }

    public void AddProblem(Problem problem)
    {
        if (IsCompleted)
            throw new DomainException("Can't add new problem to completed report");

        if (problem == null)
            throw new DomainException("Problem can't be null!");

        if (problem.State is not EProblemState.Closed)
            throw new DomainException("Problem that's not closed can't be added to the report!");

        _problems.Add(problem);
    }
}