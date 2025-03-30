using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.Topics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class TopicRequestedRoleConfiguration : IEntityTypeConfiguration<TopicRequestedRole>
{
    public void Configure(EntityTypeBuilder<TopicRequestedRole> builder)
    {
        builder.HasKey(x => new { x.TopicId, x.RoleId });
        
        builder.HasOne(x => x.Topic).WithMany().HasForeignKey(x => x.TopicId);
        builder.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
    }
}