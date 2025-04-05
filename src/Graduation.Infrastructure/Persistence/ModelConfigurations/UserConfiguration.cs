using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation.Infrastructure.Persistence.ModelConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Users");
        builder.HasIndex(e => e.Email, "Email");
        builder.HasIndex(e => e.NormalizedEmail, "NormalizedEmail").IsUnique();

        ConfigureProperties(builder);
    }

    private void ConfigureProperties(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName)
            .HasMaxLength(255);

        builder.Property(u => u.LastName)
            .HasMaxLength(255);

        builder.Property(u => u.Patronymic)
            .HasMaxLength(255);
    }
}