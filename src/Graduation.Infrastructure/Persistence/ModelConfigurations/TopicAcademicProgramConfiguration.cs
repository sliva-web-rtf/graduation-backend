using Graduation.Domain.AcademicPrograms;
using Graduation.Domain.Topics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class TopicAcademicProgramConfiguration : IEntityTypeConfiguration<TopicAcademicProgram>
{
    public void Configure(EntityTypeBuilder<TopicAcademicProgram> builder)
    {
        builder.HasKey(x => new { x.TopicId, x.AcademicProgramId });
        
        builder.HasOne<Topic>().WithMany().HasForeignKey(x => x.TopicId);
        builder.HasOne<AcademicProgram>().WithMany().HasForeignKey(x => x.AcademicProgramId);
    }
}