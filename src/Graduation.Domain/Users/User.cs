using Graduation.Domain.Users.Enums;
using Microsoft.AspNetCore.Identity;

namespace Graduation.Domain.Users;

public class User : IdentityUser<Guid>
{
    public string? FirstName { get; protected set; }

    public string? LastName { get; protected set; }

    public string? Patronymic { get; protected set; }

    public string FullName => string.Join(' ', FirstName, LastName, Patronymic);

    public DateTime? RemovedAt { get; protected set; }

    public string? Contacts { get; protected set; }

    public string? About { get; protected set; }

    public UserStatus UserStatus { get; protected set; }

    protected User(Guid id)
    {
        Id = id;
    }
}
