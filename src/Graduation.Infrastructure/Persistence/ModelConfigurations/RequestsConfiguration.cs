using Graduation.Domain.Requests;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class RequestsConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Topic>().WithMany().HasForeignKey(x => x.TopicId);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.SenderId);
        builder.HasOne<AppIdentityRole>().WithMany().HasForeignKey(x => x.SenderRoleId);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.RecipientId);
        builder.HasOne<AppIdentityRole>().WithMany().HasForeignKey(x => x.RecipientRoleId);
    }
}