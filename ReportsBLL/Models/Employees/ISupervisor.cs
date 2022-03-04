namespace ReportsBLL.Models.Employees;

public interface ISupervisor : IPerson // TODO: May be subordinate implements supervisor?
{
    public IEnumerable<ISubordinate> Subordinates { get; }
}