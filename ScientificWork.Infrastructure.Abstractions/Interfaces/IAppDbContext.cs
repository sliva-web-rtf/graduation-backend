using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;

namespace ScientificWork.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Application abstraction for unit of work.
/// </summary>
public interface IAppDbContext : IDbContextWithSets, IDisposable
{
    /// <summary>
    /// Users.
    /// </summary>
    DbSet<User> Users { get; }

    /// <summary>
    /// Professors.
    /// </summary>
    DbSet<Professor> Professors { get; }

    /// <summary>
    /// Students.
    /// </summary>
    DbSet<Student> Students { get; }

    /// <summary>
    /// Scientific works.
    /// </summary>
    DbSet<Domain.ScientificWorks.ScientificWork> ScientificWorks { get; }

    /// <summary>
    /// Scientific interests.
    /// </summary>
    DbSet<ScientificInterest> ScientificInterests { get; }

    /// <summary>
    /// Scientific interests.
    /// </summary>
    DbSet<ScientificArea> ScientificAreas { get; }

    DbSet<ScientificAreaSubsection> ScientificAreaSubsections { get; }
}
