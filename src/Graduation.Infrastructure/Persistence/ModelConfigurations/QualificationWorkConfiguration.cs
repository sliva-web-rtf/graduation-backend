using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Students;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;
using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class QualificationWorkConfiguration : IEntityTypeConfiguration<QualificationWork>
{
    public void Configure(EntityTypeBuilder<QualificationWork> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Topic>(x => x.Topic).WithMany().HasForeignKey(x => x.TopicId);
        builder.HasOne<User>(x => x.Supervisor).WithMany().HasForeignKey(x => x.SupervisorId);
        builder.HasOne<Student>().WithOne(x => x.QualificationWork).HasForeignKey<QualificationWork>(x => x.StudentId);
        builder.HasOne<QualificationWorkRole>().WithMany().HasForeignKey(x => x.QualificationWorkRoleId);
        builder.HasOne<Year>().WithMany().HasForeignKey(x => x.Year);
    }
}