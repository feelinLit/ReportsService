using Reports.Domain.Models.Employees;

namespace Reports.DAL.Data;

public static class DbInitializer
{
    public static void Initialize(ReportsDbContext context)
    {
        if (context.Employees.Any()) return;

        var teamlead = new TeamLead("UncleBob", null);
        var employee2 = new Employee("Bobuk", teamlead);
        var employee3 = new Employee("EricEvans", teamlead);
        var employee4 = new Employee("Xi", employee2);
        var employee5 = new Employee("Pudge", employee2);
        var employee6 = new Employee("JoeBiden", employee2);
        var employee7 = new Employee("ThomasCormen", employee6);
        var employee8 = new Employee("DeBill", employee6);
        context.Employees.AddRange(teamlead, employee2, employee3, employee4, employee5, employee6, employee7, employee8);

        var problem1 = employee2.AddProblem("Do Java Lab3");
        var problem2 = employee2.AddProblem("Rewrite Reports");
        var problem3 = employee4.AddProblem("Invade Taiwan");

        employee2.AddComment(problem1, "Ugh, lab is too hard");
        employee2.AddComment(problem1, "Nvm, found a useful article");
        problem1.CloseProblem();

        employee4.AddComment(problem3, "Preparing ;)");

        var reportCompleted = employee2.AddReport("My first report");
        reportCompleted.AddProblem(problem1);
        reportCompleted.IsCompleted = true;

        var reportIncomplete = teamlead.AddReport("Report on completed team aims\nEveryone did a great job!");
        
        context.SaveChanges();
    }
}