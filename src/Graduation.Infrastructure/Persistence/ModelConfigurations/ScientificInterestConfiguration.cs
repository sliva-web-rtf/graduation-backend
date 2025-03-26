using Graduation.Domain.ScientificInterest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class ScientificInterestConfiguration : IEntityTypeConfiguration<ScientificInterest>
{
    public void Configure(EntityTypeBuilder<ScientificInterest> builder)
    {
        builder.HasKey(x => x.Id);
    }
}