using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Favorites;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class StudentFavoriteScientificWorkConfigurations : IEntityTypeConfiguration<StudentFavoriteScientificWork>
{
    public void Configure(EntityTypeBuilder<StudentFavoriteScientificWork> builder)
    {
        builder.HasKey(pfs => new { pfs.StudentId, pfs.ScientificWorkId });

        builder.HasOne(dc => dc.Student)
            .WithMany(d => d.StudentFavoriteScientificWorks)
            .HasForeignKey(dc => dc.StudentId);

        builder.HasOne(dc => dc.ScientificWork)
            .WithMany()
            .HasForeignKey(dc => dc.ScientificWorkId);

        ConfigureProperties(builder);
    }

    private void ConfigureProperties(EntityTypeBuilder<StudentFavoriteScientificWork> builder)
    {
        builder.Property(pfs => pfs.IsActive)
            .IsRequired();

        builder.Property(pfs => pfs.AddedAt)
            .IsRequired();
    }
}
