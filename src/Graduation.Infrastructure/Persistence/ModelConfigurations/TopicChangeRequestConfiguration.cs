using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class TopicChangeRequestConfiguration : IEntityTypeConfiguration<TopicChangeRequest>
{
    public void Configure(EntityTypeBuilder<TopicChangeRequest> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<QualificationWork>().WithMany().HasForeignKey(x => x.QualificationWorkId);
    }
}