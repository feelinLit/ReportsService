using Microsoft.EntityFrameworkCore;
using ReportsBLL.Models.Employees;

namespace ReportsDAL.Data;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}