using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;

namespace ReportsDAL.Data;

public class ReportsDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Problem> Problems { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public ReportsDbContext(DbContextOptions<ReportsDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}