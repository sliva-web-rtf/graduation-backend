using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Users;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserTokens");
        builder.HasKey(token => new { token.UserId, token.Description });
        builder.HasOne(token => token.User)
            .WithMany()
            .HasForeignKey(token => token.UserId);
        builder.Property(token => token.IssuedAt);
    }
}
