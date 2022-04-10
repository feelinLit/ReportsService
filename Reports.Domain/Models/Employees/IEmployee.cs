using Reports.Domain.Models.Problems;
using Reports.Domain.Models.Reports;

namespace Reports.Domain.Models.Employees;

public interface IEmployee
{
    void AddComment(Problem problem, string content);
    Report AddReport(string description);
}