using Graduation.Domain.Skills;
using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        builder.HasKey(x => new { x.UserId, x.SkillId });
        
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne<Skill>().WithMany().HasForeignKey(x => x.SkillId);
    }
}