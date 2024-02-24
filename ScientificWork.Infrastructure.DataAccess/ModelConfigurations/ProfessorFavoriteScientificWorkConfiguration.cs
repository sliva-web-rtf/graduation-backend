using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Favorites;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class ProfessorFavoriteScientificWorkConfiguration : IEntityTypeConfiguration<ProfessorFavoriteScientificWork>
{
    public void Configure(EntityTypeBuilder<ProfessorFavoriteScientificWork> builder)
    {
        builder.HasKey(pfs => new { pfs.ProfessorId, pfs.ScientificWorkId });

        builder.HasOne(dc => dc.Professor)
            .WithMany(d => d.ProfessorFavoriteScientificWorks)
            .HasForeignKey(dc => dc.ProfessorId);

        builder.HasOne(dc => dc.ScientificWork)
            .WithMany()
            .HasForeignKey(dc => dc.ScientificWorkId);

        ConfigureProperties(builder);
    }

    private void ConfigureProperties(EntityTypeBuilder<ProfessorFavoriteScientificWork> builder)
    {
        builder.Property(pfs => pfs.IsActive)
            .IsRequired();

        builder.Property(pfs => pfs.AddedAt)
            .IsRequired();
    }
}
