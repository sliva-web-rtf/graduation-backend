using Graduation.Domain.Commissions;
using Graduation.Domain.Stages;
using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class CommissionStudentConfiguration : IEntityTypeConfiguration<CommissionStudent>
{
    public void Configure(EntityTypeBuilder<CommissionStudent> builder)
    {
        builder.HasKey(x => new { x.UserId, x.CommissionId, x.StageId });

        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne<Commission>().WithMany().HasForeignKey(x => x.CommissionId);
        builder.HasOne<Stage>().WithMany().HasForeignKey(x => x.StageId);
    }
}