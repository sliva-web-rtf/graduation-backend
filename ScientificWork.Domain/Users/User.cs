﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Domain.Common.Utils;
using ScientificWork.Domain.Notifications;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
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

    public string? Contacts { get; protected set; }

    public string? About { get; protected set; }

    public bool IsRegistrationComplete { get; protected set; }

    public UserStatus UserStatus { get; protected set; }

    public string? AvatarImagePath { get; protected set; }

    private readonly List<Notification> notifications = new();

    public ICollection<Notification> Notifications => notifications;

    protected readonly List<ScientificInterest> scientificInterests = new();

    public IReadOnlyList<ScientificInterest> ScientificInterests => scientificInterests.AsReadOnly();

    protected readonly List<ScientificAreaSubsection> scientificAreaSubsections = new();

    public IReadOnlyList<ScientificAreaSubsection> ScientificAreaSubsections => scientificAreaSubsections.AsReadOnly();

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

    public void SetAvatarImagePath(string path)
    {
        AvatarImagePath = path;
    }

    public abstract bool CompleteRegistration(out List<string> errors);


    public void UpdateProfileInformation(
        string firstName,
        string lastName,
        string patronymic,
        string? phoneNumber,
        string? contacts)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        Contacts = contacts;
    }

    public User()
    {
    }
}
