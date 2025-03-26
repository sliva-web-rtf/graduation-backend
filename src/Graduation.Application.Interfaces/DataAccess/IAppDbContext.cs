using Graduation.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Interfaces.DataAccess;

public interface IAppDbContext : IDbContextWithSets, IDisposable
{
    DbSet<User> Users { get; }
}
