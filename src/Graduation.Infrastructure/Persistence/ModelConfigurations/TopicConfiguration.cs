using Graduation.Domain.AcademicPrograms;
using Graduation.Domain.Topics;
using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class TopicConfiguration :  IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Owner).WithMany().HasForeignKey(x => x.OwnerId);
        builder.HasOne<Year>().WithMany().HasForeignKey(x => x.Year);
        builder.HasMany(x => x.AcademicPrograms).WithMany().UsingEntity<TopicAcademicProgram>();
        builder.HasMany(x => x.RequestedRoles).WithMany().UsingEntity<TopicRequestedRole>();
        builder.HasMany(x => x.UserRoleTopics).WithOne().HasForeignKey(x => x.TopicId);
    }
}