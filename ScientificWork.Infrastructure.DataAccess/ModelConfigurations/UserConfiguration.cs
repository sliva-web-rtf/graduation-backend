using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificWork.Domain.Users;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

/// <summary>
/// Contains database model configuration for <see cref="User"/>.
/// </summary>
internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasIndex(e => e.Email, "Email");
        builder.HasIndex(e => e.NormalizedEmail, "NormalizedEmail").IsUnique();
        builder.HasIndex(e => e.RemovedAt);

        // builder.HasQueryFilter(user => user.RemovedAt == null);

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
