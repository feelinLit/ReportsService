using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public interface IEmployee : ISubordinate, ISupervisor
{
    public void AddNewProblem(Problem problem);
    public void UpdateProblem(Problem problem);
    public Report MakeReport(Report report);
}