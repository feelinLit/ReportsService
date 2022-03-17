using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsDAL.Data;

public class ReportsDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<TeamLead> TeamLeads { get; set; }
    public DbSet<Problem> Problems { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Report> Reports { get; set; }

    public ReportsDbContext(DbContextOptions<ReportsDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}