using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;
using ReportsBLL.Models.Reports;

namespace ReportsDAL.Data.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("EmployeeId");
        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(e => e.Username).IsRequired().HasMaxLength(30);

        builder.HasMany(e => (IEnumerable<Employee>)e.Subordinates)
            .WithOne(s => (Employee)s.Supervisor)
            .HasForeignKey(e => e.SupervisorId)
            .OnDelete(DeleteBehavior.ClientSetNull); // TODO: Configure OnDelete() to set to it's supervisor
        builder.HasMany(e => e.Problems)
            .WithOne(p => p.Employee)
            .HasForeignKey(p => p.EmployeeId);
        builder.HasMany<Comment>()
            .WithOne(c => (Employee)c.Employee)
            .HasForeignKey(c => c.EmployeeId);
        builder.HasOne(e => e.Report)
            .WithOne(r => (Employee)r.Employee)
            .HasForeignKey<Report>("EmployeeId");
    }
}