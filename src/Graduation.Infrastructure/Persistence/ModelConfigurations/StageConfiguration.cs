using Graduation.Domain.Stages;
using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class StageConfiguration : IEntityTypeConfiguration<Stage>
{
    public void Configure(EntityTypeBuilder<Stage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Year>().WithMany().HasForeignKey(s => s.Year);

        var converter = new EnumToStringConverter<StageType>();
        builder.Property(x => x.Type).HasConversion(converter);
    }
}