using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Favorites;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class ScientificWorkConfiguration : IEntityTypeConfiguration<Domain.ScientificWorks.ScientificWork>
{
    public void Configure(EntityTypeBuilder<Domain.ScientificWorks.ScientificWork> builder)
    {
        builder.HasKey(w => w.Id);

        builder.HasMany(sw => sw.Students)
            .WithMany(s => s.ScientificWorks);

        builder.HasOne(sw => sw.Professor)
            .WithMany(s => s.ScientificWorks);

        builder.HasMany<Professor>()
            .WithMany(p => p.FavoriteScientificWorks)
            .UsingEntity<ProfessorFavoriteScientificWork>();
    }
}
