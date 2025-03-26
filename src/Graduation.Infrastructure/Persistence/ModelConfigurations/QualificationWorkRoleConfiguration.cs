using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class QualificationWorkRoleConfiguration : IEntityTypeConfiguration<QualificationWorkRole>
{
    public void Configure(EntityTypeBuilder<QualificationWorkRole> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Year>().WithMany().HasForeignKey(x => x.Year);
    }
}