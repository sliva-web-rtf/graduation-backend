using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Favorites;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class StudentFavoriteProfessorConfiguration : IEntityTypeConfiguration<StudentFavoriteProfessor>
{
    public void Configure(EntityTypeBuilder<StudentFavoriteProfessor> builder)
    {
        builder.HasKey(pfs => new { pfs.StudentId, pfs.ProfessorId });

        builder.HasOne(dc => dc.Student)
            .WithMany(d => d.StudentFavoriteProfessors)
            .HasForeignKey(dc => dc.StudentId);

        builder.HasOne(dc => dc.Professor)
            .WithMany()
            .HasForeignKey(dc => dc.ProfessorId);

        ConfigureProperties(builder);
    }

    private void ConfigureProperties(EntityTypeBuilder<StudentFavoriteProfessor> builder)
    {
        builder.Property(pfs => pfs.IsActive)
            .IsRequired();

        builder.Property(pfs => pfs.AddedAt)
            .IsRequired();
    }
}
