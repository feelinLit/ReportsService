using Microsoft.EntityFrameworkCore;

namespace ReportsDAL.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer()
    }
}