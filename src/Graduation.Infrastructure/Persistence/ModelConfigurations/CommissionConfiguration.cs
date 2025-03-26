using Graduation.Domain.Commissions;
using Graduation.Domain.Users;
using Graduation.Domain.Years;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

public class CommissionConfiguration : IEntityTypeConfiguration<Commission>
{
    public void Configure(EntityTypeBuilder<Commission> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.SecretaryId);
        builder.HasOne<Year>().WithMany().HasForeignKey(x => x.Year);
    }
}