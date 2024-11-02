using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.DataAccess;

namespace ScientificWork.Web.Infrastructure.Startup;

/// <summary>
/// Database context setup.
/// </summary>
internal class DbContextOptionsSetup
{
    private readonly string connectionString;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="connectionString">Connection string.</param>
    public DbContextOptionsSetup(string connectionString)
    {
        this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    /// <summary>
    /// Setup database context.
    /// </summary>
    /// <param name="options">Options.</param>
    public void Setup(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(
            connectionString,
            sqlOptions => sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name)
        );
    }
}
