using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public interface ISubordinate : IPerson
{
    public ISupervisor? Supervisor { get; set; }
    public int? SupervisorId { get; set; }
    public IList<Report> Reports { get; set; }
    public IList<Problem> Problems { get; set; }
}