namespace ReportsBLL.Models.Employees;

public interface ISupervisor : IPerson // TODO: May be subordinate implements supervisor?
{
    IEnumerable<ISubordinate> Subordinates { get; }
    void AddSubordinate(ISubordinate subordinate); // TODO: Return ISubordinate
    void AddSubordinate(string username);
    bool TryRemoveSubordinate(ISubordinate subordinate);
}