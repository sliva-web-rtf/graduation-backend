using Graduation.Domain.Users;
using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.HasKey(x => new { x.UserId, x.RoleId, x.Year });
        
        builder.HasOne<User>(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
        builder.HasOne<AppIdentityRole>(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
        builder.HasOne<Year>().WithMany().HasForeignKey(x => x.Year);
    }
}