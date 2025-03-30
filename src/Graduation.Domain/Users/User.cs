using Graduation.Domain.Users.Enums;
using Microsoft.AspNetCore.Identity;

namespace Graduation.Domain.Users;

public class User : IdentityUser<Guid>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Patronymic { get; set; }

    public string FullName => string.Join(' ', LastName, FirstName, Patronymic);

    public string? Contacts { get; set; }

    public string? About { get; set; }

    public UserStatus UserStatus { get; set; }

    public User(Guid id)
    {
        Id = id;
        UserStatus = UserStatus.Active;
    }

    public static User Create(Guid id,
        string userName,
        string? email,
        string firstName,
        string lastName,
        string patronymic,
        string? contacts,
        string? about)
    {
        var user = new User(id);
        user.UpdateProfileInfo(userName, email, firstName, lastName, patronymic, contacts, about);
        return user;
    }

    public void UpdateProfileInfo(string userName,
        string? email,
        string firstName,
        string lastName,
        string patronymic,
        string? contacts,
        string? about)
    {
        UserName = userName;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Contacts = contacts;
        About = about;
    }
}