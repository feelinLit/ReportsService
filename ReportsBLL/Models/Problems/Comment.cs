using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Employees;
using ReportsBLL.Tools;

namespace ReportsBLL.Models.Problems;

public class Comment : BaseEntity
{
    protected Comment()
    {
    }

    public Comment(string content, ISubordinate employee, Problem problem)
    {
        Content = content ?? throw new ReportsServiceException("Content can't be null of a comment!");
        AssignedEmployee = employee ?? throw new ReportsServiceException("Assigned employee can't be null!");
        AssignedEmployeeId = employee.Id;
        if (employee.Problems.All(p => !p.Equals(problem)))
        {
            throw new ReportsServiceException($"Employee {employee.Username} not assigned for problem Id={problem.Id}!");
        }
        Problem = problem ?? throw new ReportsServiceException("Commenting problem can't be null!");
        ProblemId = problem.Id;
    }

    [Required] public string Content { get; }

    [Required] public DateTime CreationTime { get; } = DateTime.Now;
    
    [Required] public ulong AssignedEmployeeId { get; }
    [Required] public ISubordinate AssignedEmployee { get; }

    [Required] public ulong ProblemId { get; }
    [Required] public Problem Problem { get; } // TODO: Encapsulation
}