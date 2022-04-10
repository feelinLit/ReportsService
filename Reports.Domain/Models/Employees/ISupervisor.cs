namespace Reports.Domain.Models.Employees;

public interface ISupervisor : IPerson // TODO: May be subordinate implements supervisor?
{
    IEnumerable<ISubordinate> Subordinates { get; }
    void AddSubordinate(ISubordinate subordinate);
    void AddSubordinate(string username);
    bool TryRemoveSubordinate(ISubordinate subordinate);
}