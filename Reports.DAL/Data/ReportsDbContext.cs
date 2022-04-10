using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Reports.Domain.Models.Employees;
using Reports.Domain.Models.Problems;
using Reports.Domain.Models.Reports;

namespace Reports.DAL.Data;

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