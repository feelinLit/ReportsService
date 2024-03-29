﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reports.Domain.Models.Employees;
using Reports.Domain.Models.Reports;

namespace Reports.DAL.Data.Configuration;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Report");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasColumnName("ReportId");
        builder.Property<ulong>("EmployeeId")
            .IsRequired();
        builder.Property(r => r.Description)
            .IsRequired();
        builder.Property(r => r.IsCompleted)
            .HasColumnName("Status")
            .HasConversion(new BoolToStringConverter("On draft", "Completed"));

        builder.HasMany(r => r.Problems)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(r => (Employee)r.Employee)
            .WithOne(e => e.Report);
    }
}