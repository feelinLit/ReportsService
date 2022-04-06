using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public interface IEmployee
{
    void AddComment(Problem problem, string content);
    Report AddReport(string description);
}