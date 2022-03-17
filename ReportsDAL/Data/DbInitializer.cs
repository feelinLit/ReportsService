using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsDAL.Data;

public static class DbInitializer
{
    public static void Initialize(ReportsDbContext context)
    {
        if (context.Employees.Any()) return;

        var teamlead = new TeamLead("Lolek", null);
        var employee2 = new Employee("Kolek", teamlead);
        var employee3 = new Employee("Jojek", teamlead);
        var employee4 = new Employee("Xi", employee2);
        context.Employees.AddRange(teamlead, employee2, employee3, employee4);

        var problem1 = employee2.AddProblem("Do Java Lab3");
        var problem2 = employee2.AddProblem("Rewrite Reports");
        var problem3 = employee4.AddProblem("Invade Taiwan");

        employee2.AddComment(problem1, "Ugh, lab is too hard");
        employee2.AddComment(problem1, "Nvm, found a useful article");
        problem1.CloseProblem();

        employee4.AddComment(problem3, "Preparing ;)");

        var report = employee2.AddReport("My first report");
        report.AddProblem(problem1);
        report.IsCompleted = true;

        context.SaveChanges();
    }
}