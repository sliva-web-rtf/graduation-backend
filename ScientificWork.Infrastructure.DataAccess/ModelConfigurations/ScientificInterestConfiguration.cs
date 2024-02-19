using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.ScientificInterests;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class ScientificInterestConfiguration : IEntityTypeConfiguration<ScientificInterest>
{
    public void Configure(EntityTypeBuilder<ScientificInterest> builder)
    {
        builder.HasKey(i => i.Id);
    }
}
