using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Common.Utils;
using ScientificWork.Domain.Notifications;
using ScientificWork.Domain.Users.Enums;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace ScientificWork.Domain.Users;

/// <summary>
/// Custom application user entity.
/// </summary>
public abstract class User : IdentityUser<Guid>
{
    /// <summary>
    /// First name.
    /// </summary>
    [MaxLength(255)]
    public string? FirstName { get; protected set; }

    /// <summary>
    /// Last name.
    /// </summary>
    [MaxLength(255)]
    public string? LastName { get; protected set; }

    /// <summary>
    /// Patronymic.
    /// </summary>
    [MaxLength(255)]
    public string? Patronymic { get; protected set; }

    /// <summary>
    /// Full name, concat of first name and last name.
    /// </summary>
    public string FullName => StringUtils.JoinIgnoreEmpty(separator: " ", FirstName, LastName);

    /// <summary>
    /// The date when user last logged in.
    /// </summary>
    public DateTime? LastLogin { get; protected set; }

    /// <summary>
    /// Last token reset date. Before the date all generate login tokens are considered
    /// not valid. Must be in UTC format.
    /// </summary>
    public DateTime LastTokenResetAt { get; protected set; } = DateTime.UtcNow;

    /// <summary>
    /// Indicates when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; protected set; }

    /// <summary>
    /// Indicates when the user was updated.
    /// </summary>
    public DateTime UpdatedAt { get; protected set; }

    /// <summary>
    /// Indicates when the user was removed.
    /// </summary>
    public DateTime? RemovedAt { get; protected set; }

    public UserStatus UserStatus { get; protected set; }

    public Guid AvatarImageId { get; protected set; }

    private readonly List<Notification> notifications = new();

    public ICollection<Notification> Notifications => notifications;

    protected User(Guid id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateLastLogin()
    {
        LastLogin = DateTime.UtcNow;
    }

    public User()
    {
    }
}
