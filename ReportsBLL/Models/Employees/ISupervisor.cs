namespace ReportsBLL.Models.Employees;

public interface ISupervisor : IPerson // TODO: May be subordinate implements supervisor?
{
    public IEnumerable<ISubordinate> Subordinates { get; }
    public void AddSubordinate(ISubordinate subordinate); // TODO: Destruct subordinate
    public void AddSubordinate(string username);
}