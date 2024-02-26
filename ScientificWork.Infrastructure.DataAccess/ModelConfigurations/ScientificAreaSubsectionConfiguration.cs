using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.ScientificAreas;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class ScientificAreaSubsectionConfiguration : IEntityTypeConfiguration<ScientificAreaSubsection>
{
    public void Configure(EntityTypeBuilder<ScientificAreaSubsection> builder)
    {
        builder.HasKey(i => i.Id);
    }
}
