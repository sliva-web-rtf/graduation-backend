using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Favorites;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class ProfessorFavoriteStudentConfiguration : IEntityTypeConfiguration<ProfessorFavoriteStudent>
{
    public void Configure(EntityTypeBuilder<ProfessorFavoriteStudent> builder)
    {
        builder.HasKey(pfs => new { pfs.ProfessorId, pfs.StudentId });

        builder.HasOne(dc => dc.Professor)
            .WithMany(d => d.ProfessorFavoriteStudents)
            .HasForeignKey(dc => dc.ProfessorId);

        builder.HasOne(dc => dc.Student)
            .WithMany()
            .HasForeignKey(dc => dc.StudentId);

        ConfigureProperties(builder);
    }

    private void ConfigureProperties(EntityTypeBuilder<ProfessorFavoriteStudent> builder)
    {
        builder.Property(pfs => pfs.IsActive)
            .IsRequired();

        builder.Property(pfs => pfs.AddedAt)
            .IsRequired();
    }
}
