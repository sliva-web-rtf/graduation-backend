using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class UserRoleTopicConfiguration : IEntityTypeConfiguration<UserRoleTopic>
{
    public void Configure(EntityTypeBuilder<UserRoleTopic> builder)
    {
        builder.HasKey(x => new { x.UserId, x.TopicId, x.QualificationWorkRoleId });
        
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne<Topic>().WithMany().HasForeignKey(x => x.TopicId);
        builder.HasOne<QualificationWorkRole>().WithMany().HasForeignKey(x => x.QualificationWorkRoleId);
    }
}