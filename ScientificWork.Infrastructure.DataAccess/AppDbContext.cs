using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ScientificWork.Domain.Admins;
using ScientificWork.Domain.Notifications;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

namespace ScientificWork.Infrastructure.DataAccess;

/// <summary>
/// Application unit of work.
/// </summary>
public class AppDbContext
    : IdentityDbContext<User, AppIdentityRole, Guid>,
    IAppDbContext,
    IDataProtectionKeyContext
{
    /// <inheritdoc/>
    public DbSet<DataProtectionKey> DataProtectionKeys { get; private set; }

    /// <inheritdoc/>
    public DbSet<Professor> Professors { get; private set; }

    /// <inheritdoc/>
    public DbSet<Student> Students { get; private set; }

    /// <inheritdoc/>
    public DbSet<Domain.ScientificWorks.ScientificWork> ScientificWorks { get; private set; }

    /// <inheritdoc/>
    public DbSet<ScientificInterest> ScientificInterests { get; private set; }

    /// <inheritdoc/>
    public DbSet<ScientificArea> ScientificAreas { get; private set; }

    /// <inheritdoc/>
    public DbSet<Notification> Notifications { get; private set; }

    /// <inheritdoc/>
    public DbSet<SystemAdmin> SystemAdmins { get; private set; }

    public DbSet<UserToken> UserSecurityTokens { get; private set; }

    /// <inheritdoc/>
    public DbSet<ScientificAreaSubsection> ScientificAreaSubsections { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="Microsoft.EntityFrameworkCore.DbContext" />.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.CreateDefaultScientificArea();
        base.OnModelCreating(modelBuilder);

        RestrictCascadeDelete(modelBuilder);
        ForceHavingAllStringsAsVarchars(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    private static void RestrictCascadeDelete(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    private static void ForceHavingAllStringsAsVarchars(ModelBuilder modelBuilder)
    {
        var stringColumns = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.ClrType == typeof(string));
        foreach (IMutableProperty mutableProperty in stringColumns)
        {
            mutableProperty.SetIsUnicode(false);
        }
    }
}
