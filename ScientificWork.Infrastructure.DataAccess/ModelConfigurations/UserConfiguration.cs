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
        builder.Property(e => e.CreatedAt)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("now() at time zone 'UTC'");
        builder.Property(e => e.UpdatedAt)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("now() at time zone 'UTC'");
        builder.Property(e => e.RemovedAt)
            .HasComment("For soft-deletes")
            .HasColumnType("timestamp");

        // builder.HasQueryFilter(user => user.RemovedAt == null);

        ConfigureProperties(builder);
    }

    private void ConfigureProperties(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Patronymic)
            .HasMaxLength(255);
    }
}
