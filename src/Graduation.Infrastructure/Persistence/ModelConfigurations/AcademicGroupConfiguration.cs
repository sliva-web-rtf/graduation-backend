using Graduation.Domain.AcademicGroups;
using Graduation.Domain.AcademicPrograms;
using Graduation.Domain.Commissions;
using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class AcademicGroupConfiguration :  IEntityTypeConfiguration<AcademicGroup>
{
    public void Configure(EntityTypeBuilder<AcademicGroup> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne<Commission>().WithMany().HasForeignKey(x => x.CommissionId);
        builder.HasOne<AcademicProgram>(x => x.AcademicProgram).WithMany().HasForeignKey(x => x.AcademicProgramId);
        builder.HasOne<Year>().WithMany().HasForeignKey(x => x.Year);
    }
}