using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;

namespace ReportsDAL.Data.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(e => e.Username).IsRequired().HasMaxLength(30);

        builder.HasMany(e => (ICollection<Employee>)e.Subordinates)
            .WithOne(s => (Employee)s.Supervisor)
            .HasForeignKey(e => e.SupervisorId);
        builder.HasMany(e => e.Problems)
            .WithOne(p => p.Employee)
            .HasForeignKey(p => p.EmployeeId);
        builder.HasMany<Comment>()
            .WithOne(c => (Employee)c.AssignedEmployee)
            .HasForeignKey(c => c.AssignedEmployeeId);
    }
}