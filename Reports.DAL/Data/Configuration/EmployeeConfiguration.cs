﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reports.Domain.Models.Employees;
using Reports.Domain.Models.Problems;
using Reports.Domain.Models.Reports;

namespace Reports.DAL.Data.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("EmployeeId");
        builder.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Username)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasMany(e => (IEnumerable<Employee>)e.Subordinates)
            .WithOne(s => (Employee)s.Supervisor)
            .HasForeignKey(e => e.SupervisorId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(e => e.Problems)
            .WithOne(p => (Employee)p.Employee)
            .HasForeignKey(p => p.EmployeeId);
        builder.HasMany<Comment>()
            .WithOne(c => (Employee)c.Employee)
            .HasForeignKey(c => c.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(e => e.Report)
            .WithOne(r => (Employee)r.Employee)
            .HasForeignKey<Report>("EmployeeId");
    }
}