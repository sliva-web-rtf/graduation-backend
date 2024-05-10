using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Requests;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class StudentRequestStudentConfiguration : IEntityTypeConfiguration<StudentRequestStudent>
{
    public void Configure(EntityTypeBuilder<StudentRequestStudent> builder)
    {
        builder.HasKey(pfs => new { pfs.StudentFromId, pfs.StudentToId, pfs.Id });

        builder.HasOne(dc => dc.StudentFrom)
            .WithMany(d => d.StudentRequestStudents)
            .HasForeignKey(dc => dc.StudentFromId);

        builder.HasOne(dc => dc.StudentTo)
            .WithMany()
            .HasForeignKey(dc => dc.StudentToId);

        ConfigureProperties(builder);
    }

    private void ConfigureProperties(EntityTypeBuilder<StudentRequestStudent> builder)
    {
        builder.Property(pfs => pfs.IsActive)
            .IsRequired();
    }
}
