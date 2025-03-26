using Graduation.Domain.Commissions;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Stages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class QualificationWorkStageConfiguration : IEntityTypeConfiguration<QualificationWorkStage>
{
    public void Configure(EntityTypeBuilder<QualificationWorkStage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Stage>().WithMany().HasForeignKey(x => x.StageId);
        builder.HasOne<QualificationWork>().WithMany().HasForeignKey(x => x.QualificationWorkId);
        builder.HasOne<Commission>().WithMany().HasForeignKey(x => x.CommissionId);
    }
}