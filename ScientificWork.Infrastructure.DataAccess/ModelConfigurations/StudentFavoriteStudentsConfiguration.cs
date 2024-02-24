using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Favorites;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class StudentFavoriteStudentsConfiguration : IEntityTypeConfiguration<StudentFavoriteStudent>
{
    public void Configure(EntityTypeBuilder<StudentFavoriteStudent> builder)
    {
        builder.HasKey(pfs => new { pfs.StudentId, pfs.FavoriteStudentId });

        builder.HasOne(dc => dc.Student)
            .WithMany(d => d.StudentFavoriteStudents)
            .HasForeignKey(dc => dc.StudentId);

        builder.HasOne(dc => dc.FavoriteStudent)
            .WithMany()
            .HasForeignKey(dc => dc.FavoriteStudentId);

        ConfigureProperties(builder);
    }

    private void ConfigureProperties(EntityTypeBuilder<StudentFavoriteStudent> builder)
    {
        builder.Property(pfs => pfs.IsActive)
            .IsRequired();

        builder.Property(pfs => pfs.AddedAt)
            .IsRequired();
    }
}
