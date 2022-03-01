using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Employees;

namespace ReportsBLL.Models.Problems;

public class Problem : BaseEntity
{
    public Problem(string description)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description)); // TODO: Custom exceptions
    }

    public Problem(string description, Employee? employee)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Employee = employee;
        EmployeeId = employee?.Id;
        State = employee == null ? EProblemState.Open : EProblemState.Active;
    }

    [Required]
    public DateTime CreationTime { get; } = DateTime.Now;

    [Required, MaxLength(100)] // TODO: Think of removing annotations from domain entities
    public string Description { get; }

    public Employee? Employee { get; } // TODO: Change with interface
    public ulong? EmployeeId { get; }

    public EProblemState State { get; } = EProblemState.Open;

    public IList<Comment> Comments { get; } = new List<Comment>();
}