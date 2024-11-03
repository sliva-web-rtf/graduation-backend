using Extensions.Hosting.AsyncInitialization;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.DataAccess;

namespace ScientificWork.Web.Infrastructure.Startup;

/// <summary>
/// Contains database migration helper methods.
/// </summary>
public sealed class DatabaseInitializer : IAsyncInitializer
{
    private readonly AppDbContext appDbContext;

    /// <summary>
    /// Database initializer. Performs migration and data seed.
    /// </summary>
    /// <param name="appDbContext">Data context.</param>
    public DatabaseInitializer(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    /// <inheritdoc />
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await appDbContext.Database.MigrateAsync(cancellationToken);
    }
}
