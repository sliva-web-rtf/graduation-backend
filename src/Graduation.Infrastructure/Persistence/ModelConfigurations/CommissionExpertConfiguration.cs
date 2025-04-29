using Graduation.Domain.Commissions;
using Graduation.Domain.Stages;
using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class CommissionExpertConfiguration : IEntityTypeConfiguration<CommissionExpert>
{
    public void Configure(EntityTypeBuilder<CommissionExpert> builder)
    {
        builder.HasKey(x => new { x.UserId, x.CommissionId, x.StageId });

        builder.HasOne<User>(x => x.Expert).WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne<Commission>().WithMany(x => x.CommissionExperts).HasForeignKey(x => x.CommissionId);
        builder.HasOne<Stage>().WithMany().HasForeignKey(x => x.StageId);
    }
}