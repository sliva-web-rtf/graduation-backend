using Graduation.Domain.Commissions;
using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Stages;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class QualificationWorkStageConfiguration : IEntityTypeConfiguration<QualificationWorkStage>
{
    public void Configure(EntityTypeBuilder<QualificationWorkStage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Stage>(x => x.Stage).WithMany().HasForeignKey(x => x.StageId);
        builder.HasOne<QualificationWork>().WithMany(x => x.Stages).HasForeignKey(x => x.QualificationWorkId);
        builder.HasOne<Commission>().WithMany().HasForeignKey(x => x.CommissionId);
        builder.HasOne<Topic>(x => x.Topic).WithMany().HasForeignKey(x => x.TopicId);
        builder.HasOne<User>(x => x.Supervisor).WithMany().HasForeignKey(x => x.SupervisorId);
        builder.HasOne<QualificationWorkRole>(x => x.QualificationWorkRole).WithMany()
            .HasForeignKey(x => x.QualificationWorkRoleId);
    }
}