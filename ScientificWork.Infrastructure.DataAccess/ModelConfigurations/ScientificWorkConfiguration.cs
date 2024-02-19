using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class ScientificWorkConfiguration : IEntityTypeConfiguration<Domain.ScientificWorks.ScientificWork>
{
    public void Configure(EntityTypeBuilder<Domain.ScientificWorks.ScientificWork> builder)
    {
        builder.HasKey(w => w.Id);
    }
}
