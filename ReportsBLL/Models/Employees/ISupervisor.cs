namespace ReportsBLL.Models.Employees;

public interface ISupervisor : IPerson
{
    public IList<ISubordinate> Subordinates { get; set; }
}