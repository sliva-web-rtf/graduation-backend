using Graduation.Domain.Documents;
using Graduation.Domain.QualificationWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class DocumentsConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<QualificationWork>().WithMany(x => x.Documents).HasForeignKey(x => x.QualificationWorkId);
    }
}