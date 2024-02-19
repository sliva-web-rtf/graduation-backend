using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.ScientificAreas;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class ScientificAreaConfiguration : IEntityTypeConfiguration<ScientificArea>
{
    public void Configure(EntityTypeBuilder<ScientificArea> builder)
    {
        builder.HasKey(a => a.Id);
    }
}
