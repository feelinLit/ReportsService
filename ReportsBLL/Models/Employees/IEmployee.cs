using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public interface IEmployee
{
    public void AddComment(Problem problem, string content);
    public void CreateReport(string description);
}