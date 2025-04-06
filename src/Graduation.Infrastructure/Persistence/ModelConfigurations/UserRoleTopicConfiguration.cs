using Graduation.Domain.Topics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class UserRoleTopicConfiguration : IEntityTypeConfiguration<UserRoleTopic>
{
    public void Configure(EntityTypeBuilder<UserRoleTopic> builder)
    {
        builder.HasKey(x => new { x.UserId, x.TopicId });

        builder.HasOne(x => x.User).WithMany(x => x.UserRoleTopics).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.QualificationWorkRole).WithMany().HasForeignKey(x => x.QualificationWorkRoleId);
        builder.HasOne(x => x.Topic).WithMany(x => x.UserRoleTopics).HasForeignKey(x => x.TopicId);
    }
}