using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Interfaces.DataAccess;

public interface IDbContextWithSets
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
