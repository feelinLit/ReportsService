using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsBLL.Models.Employees;

public interface IEmployee
{
    public void CommentProblem(Problem problem); // TODO: Add comment
    public Report MakeReport(Report report);
}