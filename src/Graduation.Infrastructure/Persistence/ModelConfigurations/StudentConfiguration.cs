using Graduation.Domain.AcademicGroups;
using Graduation.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class StudentConfiguration :  IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasOne<AcademicGroup>().WithMany().HasForeignKey(x => x.AcademicGroupId);
    }
}