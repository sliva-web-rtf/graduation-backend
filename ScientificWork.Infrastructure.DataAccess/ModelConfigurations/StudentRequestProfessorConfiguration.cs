using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Requests;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class StudentRequestProfessorConfiguration : IEntityTypeConfiguration<StudentRequestProfessor>
{
    public void Configure(EntityTypeBuilder<StudentRequestProfessor> builder)
    {
        builder.HasKey(pfs => new { pfs.StudentId, pfs.ProfessorId, pfs.Id });

        builder.HasOne(dc => dc.Student)
            .WithMany(d => d.StudentRequestProfessors)
            .HasForeignKey(dc => dc.StudentId);

        builder.HasOne(dc => dc.Professor)
            .WithMany(d => d.StudentRequestProfessors)
            .HasForeignKey(dc => dc.ProfessorId);

        ConfigureProperties(builder);
    }

    private void ConfigureProperties(EntityTypeBuilder<StudentRequestProfessor> builder)
    {
        builder.Property(pfs => pfs.IsActive)
            .IsRequired();
    }
}
