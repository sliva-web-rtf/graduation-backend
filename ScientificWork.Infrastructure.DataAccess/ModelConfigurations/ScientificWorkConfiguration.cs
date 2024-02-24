using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Students;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class ScientificWorkConfiguration : IEntityTypeConfiguration<Domain.ScientificWorks.ScientificWork>
{
    public void Configure(EntityTypeBuilder<Domain.ScientificWorks.ScientificWork> builder)
    {
        builder.HasKey(w => w.Id);

        builder.HasMany(sw => sw.Students)
            .WithMany(s => s.ScientificWorks);
    }
}
