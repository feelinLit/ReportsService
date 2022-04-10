using Reports.Domain.Interfaces;
using Reports.Domain.Models.Employees;
using Reports.Domain.Tools.Exceptions;

namespace Reports.Domain.Models.Problems;

public class Problem : BaseEntity
{
    private readonly List<Comment> _comments = new();
    private IPerson _employee;
    private string _description;

    public Problem(string description)
    {
        if (string.IsNullOrEmpty(description))
            throw new DomainException(
                "Problem's description can't be null or empty!",
                new ArgumentNullException(nameof(description)));
        Description = description;
    }

    public Problem(string description, IPerson employee)
    {
        if (string.IsNullOrEmpty(description))
            throw new DomainException(
                "Problem's description can't be null or empty!",
                new ArgumentNullException(nameof(description)));
        Description = description;

        Employee = employee;
        EmployeeId = employee.Id;
    }

    public DateTime CreationTime { get; } = DateTime.Now;

    public string Description
    {
        get => _description;
        private set
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Problem's description can't be null or empty");
            _description = value;
        }
    }

    public IPerson Employee
    {
        get => _employee;
        set => _employee = value ?? throw new DomainException("Assigned to the problem employee can't be null!");
    }

    public ulong EmployeeId { get; }

    public EProblemState State { get; private set; } = EProblemState.Open;

    public IEnumerable<Comment> Comments => _comments;

    public void Update(string description, IPerson employee)
    {
        Description = description;
        Employee = employee; // TODO: in service?
    }

    public void AddComment(string content, ISubordinate employee)
    {
        if (State == EProblemState.Closed) throw new DomainException("Can't add comments to closed problem");
        _comments.Add(new Comment(content, employee, this));
        State = EProblemState.Active;
    }

    public void CloseProblem()
    {
        State = EProblemState.Closed;
    }
}