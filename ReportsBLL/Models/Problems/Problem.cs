using ReportsBLL.Interfaces;
using ReportsBLL.Models.Employees;
using ReportsBLL.Tools;

namespace ReportsBLL.Models.Problems;

public class Problem : BaseEntity, IAggregateRoot
{
    private readonly HashSet<Comment> _comments;

    public Problem(string description)
    {
        if (string.IsNullOrEmpty(description))
            throw new DomainException(
                "Problem's description can't be null or empty!",
                new ArgumentNullException(nameof(description)));
        Description = description;

        State = EProblemState.Open;
    }

    public Problem(string description, IPerson? employee)
    {
        if (string.IsNullOrEmpty(description))
            throw new DomainException(
                "Problem's description can't be null or empty!",
                new ArgumentNullException(nameof(description)));
        Description = description;

        Employee = employee;
        EmployeeId = employee?.Id;
        State = employee == null ? EProblemState.Open : EProblemState.Active;
    }

    public DateTime CreationTime { get; } = DateTime.Now;
    public string Description { get; }

    public IPerson? Employee { get; } // TODO: Change with interface
    public ulong? EmployeeId { get; } // TODO: field

    public EProblemState State { get; } = EProblemState.Open;

    public IEnumerable<Comment> Comments => _comments;

    public void AddComment(string content, ISubordinate employee) =>
        _comments.Add(new Comment(content, employee, this));
}