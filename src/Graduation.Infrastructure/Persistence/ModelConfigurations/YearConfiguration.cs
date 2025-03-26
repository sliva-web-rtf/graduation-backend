using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class YearConfiguration : IEntityTypeConfiguration<Year>
{
    public void Configure(EntityTypeBuilder<Year> builder)
    {
        builder.HasKey(x => x.YearName);
    }
}