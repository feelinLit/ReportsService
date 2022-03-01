using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;

namespace ReportsDAL.Data;

public static class DbInitializer
{
    public static void Initialize(ReportsDbContext context)
    {
        if (context.Employees.Any())
        {
            return;
        }

        var teamlead = new TeamLead("Lolek", null);
        var employee2 = new Employee("Kolek", teamlead);
        var employee3 = new Employee("Jojek", teamlead);
        var employee4 = new Employee("Vovik", employee2);
        context.Employees.AddRange(teamlead, employee2, employee3, employee4);
        context.SaveChanges();

        var problems = new Problem[]
        {
            new Problem("Do Java Lab2", teamlead),
            new Problem("Do housework"),
        };
        context.Problems.AddRange(problems);
        context.SaveChanges();

        var comments = new Comment[]
        {
            new Comment("First subtask completed", teamlead, problems[0]),
        };
        context.Comments.AddRange(comments);
        context.SaveChanges();
    }
}