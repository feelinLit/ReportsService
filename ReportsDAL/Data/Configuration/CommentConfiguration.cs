using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportsBLL.Models.Employees;
using ReportsBLL.Models.Problems;

namespace ReportsDAL.Data.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("CommentId");
        builder.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(c => c.Content).IsRequired();
        builder.Property(c => c.CreationTime).IsRequired();

        builder.HasOne(c => (Employee)c.Employee);
        builder.HasOne(c => c.Problem)
            .WithMany(p => p.Comments);
    }
}