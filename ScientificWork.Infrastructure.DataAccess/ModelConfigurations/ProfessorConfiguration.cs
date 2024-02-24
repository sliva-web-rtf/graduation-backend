using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Favorites;
using ScientificWork.Domain.Professors;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.ToTable("Professors");

        ConfigureProfessorFavoriteScientificWorks(builder);
        ConfigureProfessorFavoriteStudents(builder);
    }

    private void ConfigureProfessorFavoriteStudents(EntityTypeBuilder<Professor> builder)
    {
        builder.HasMany(p => p.ProfessorFavoriteStudents)
            .WithOne(pfs => pfs.Professor);

        builder.HasMany(d => d.FavoriteStudents)
            .WithMany()
            .UsingEntity<ProfessorFavoriteStudent>();
    }

    private void ConfigureProfessorFavoriteScientificWorks(EntityTypeBuilder<Professor> builder)
    {
        builder.HasMany(p => p.ProfessorFavoriteScientificWorks)
            .WithOne(pfs => pfs.Professor);

        builder.HasMany(d => d.FavoriteScientificWorks)
            .WithMany()
            .UsingEntity<ProfessorFavoriteScientificWork>();
    }
}
