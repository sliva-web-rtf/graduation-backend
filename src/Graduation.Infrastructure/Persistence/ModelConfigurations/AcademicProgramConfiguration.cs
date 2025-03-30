using Graduation.Domain.AcademicPrograms;
using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class AcademicProgramConfiguration : IEntityTypeConfiguration<AcademicProgram>
{
    public void Configure(EntityTypeBuilder<AcademicProgram> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne<Year>().WithMany().HasForeignKey(x => x.Year);
    }
}