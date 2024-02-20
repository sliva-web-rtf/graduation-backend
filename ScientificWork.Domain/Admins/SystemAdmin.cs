using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.Admins;

public class SystemAdmin : User
{
    private SystemAdmin(Guid id,
        string email,
        string firstName,
        string lastName)
        : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public static SystemAdmin Create(
        string email,
        string firstName,
        string lastName)
    {
        return new SystemAdmin(Guid.NewGuid(), email, firstName, lastName);
    }
}
