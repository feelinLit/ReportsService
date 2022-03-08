using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

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

        // var problems = new Problem[]
        // {
        //     new Problem("Do Java Lab2", employee2),
        //     new Problem("Do housework"),
        // };
        // context.Problems.AddRange(problems);
        employee2.AddProblem("Do Java Lab3");
        context.SaveChanges();

        // var comments = new Comment[]
        // {
        //     new Comment("First subtask completed", employee2, problems[0]), // TODO: Change with Problem.AddComment
        // };
        // context.Comments.AddRange(comments);
        // context.SaveChanges();
        //
        // var report1 = new Report("My first test report", employee2); // TODO: Change with Employee.AddReport
        // report1.AddProblem(problems[0]);
        // context.Reports.Add(report1);
        // context.SaveChanges();

    }
}