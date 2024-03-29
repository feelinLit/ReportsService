﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reports.Domain.Models.Employees;
using Reports.Domain.Models.Problems;

namespace Reports.DAL.Data.Configuration;

public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
{
    public void Configure(EntityTypeBuilder<Problem> builder)
    {
        builder.ToTable("Problem");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnName("ProblemId");
        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.State)
            .HasConversion(new EnumToStringConverter<EProblemState>());
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.CreationTime)
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.HasOne(p => (Employee)p.Employee)
            .WithMany(e => e.Problems);
        builder.HasMany(p => p.Comments)
            .WithOne(c => c.Problem)
            .HasForeignKey(c => c.ProblemId);
    }
}