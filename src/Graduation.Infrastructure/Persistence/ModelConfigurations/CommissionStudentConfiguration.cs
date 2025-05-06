using Graduation.Domain.Commissions;
using Graduation.Domain.Stages;
using Graduation.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class CommissionStudentConfiguration : IEntityTypeConfiguration<CommissionStudent>
{
    public void Configure(EntityTypeBuilder<CommissionStudent> builder)
    {
        builder.HasKey(x => new { x.UserId, x.CommissionId, x.StageId });

        builder.HasOne<Student>(x => x.Student).WithMany(s => s.CommissionStudents).HasForeignKey(x => x.UserId);
        builder.HasOne<Commission>(cs => cs.Commission).WithMany(x => x.CommissionStudents)
            .HasForeignKey(x => x.CommissionId);
        builder.HasOne<Stage>(x => x.Stage).WithMany().HasForeignKey(x => x.StageId);
    }
}