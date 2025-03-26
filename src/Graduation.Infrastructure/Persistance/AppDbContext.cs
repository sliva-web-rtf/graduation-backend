using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Users;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Infrastructure.Persistance;

public class AppDbContext
    : IdentityDbContext<User, AppIdentityRole, Guid>,
    IAppDbContext,
    IDataProtectionKeyContext
{
    public DbSet<DataProtectionKey> DataProtectionKeys { get; private set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
