using Graduation.Domain.Users;
using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class SupervisorLimitConfiguration : IEntityTypeConfiguration<SupervisorLimit>
{
    public void Configure(EntityTypeBuilder<SupervisorLimit> builder)
    {
        builder.HasKey(x => new { x.UserId, YearId = x.Year });

        builder.HasOne<User>(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne<Year>().WithMany().HasForeignKey(x => x.Year);
    }
}