using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Notifications;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(n => n.Id);

        builder.HasOne(n => n.Receiver)
            .WithMany(n => n.Notifications)
            .HasForeignKey(n => n.ReceiverId)
            .IsRequired();
    }
}
