using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Favorites;
using ScientificWork.Domain.Students;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.OwnsOne(s => s.SearchStatus);

        ConfigureStudentFavoriteStudents(builder);
        ConfigureStudentFavoriteScientificWorks(builder);
        ConfigureStudentFavoriteProfessors(builder);
    }

    private void ConfigureStudentFavoriteStudents(EntityTypeBuilder<Student> builder)
    {
        builder.HasMany(p => p.StudentFavoriteStudents)
            .WithOne(pfs => pfs.Student);

        builder.HasMany(d => d.FavoriteStudents)
            .WithMany()
            .UsingEntity<StudentFavoriteStudent>();
    }

    private void ConfigureStudentFavoriteScientificWorks(EntityTypeBuilder<Student> builder)
    {
        builder.HasMany(p => p.StudentFavoriteScientificWorks)
            .WithOne(pfs => pfs.Student);

        builder.HasMany(d => d.FavoriteScientificWorks)
            .WithMany()
            .UsingEntity<StudentFavoriteScientificWork>();
    }

    private void ConfigureStudentFavoriteProfessors(EntityTypeBuilder<Student> builder)
    {
        builder.HasMany(p => p.StudentFavoriteProfessors)
            .WithOne(pfs => pfs.Student);

        builder.HasMany(d => d.FavoriteProfessors)
            .WithMany()
            .UsingEntity<StudentFavoriteProfessor>();
    }
}
