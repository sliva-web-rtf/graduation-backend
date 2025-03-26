using Graduation.Domain.ScientificInterest;
using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class UserScientificInterestConfiguration :  IEntityTypeConfiguration<UserScientificInterest>
{
    public void Configure(EntityTypeBuilder<UserScientificInterest> builder)
    {
        builder.HasKey(x => new { x.UserId, x.ScientificInterestId });
        
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne<ScientificInterest>().WithMany().HasForeignKey(x => x.ScientificInterestId);
    }
}