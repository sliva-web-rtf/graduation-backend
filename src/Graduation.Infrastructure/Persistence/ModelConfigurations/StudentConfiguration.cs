using Graduation.Domain.AcademicGroups;
using Graduation.Domain.Commissions;
using Graduation.Domain.Students;
using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class StudentConfiguration :  IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        
        builder.HasKey(x => x.Id);
        
        builder.HasOne<User>(x => x.User).WithOne().HasForeignKey<Student>(x => x.Id);
        builder.HasOne<AcademicGroup>(x => x.AcademicGroup).WithMany().HasForeignKey(x => x.AcademicGroupId);
        builder.HasMany(s => s.CommissionStudents).WithOne().HasForeignKey(x => x.UserId);
    }
}