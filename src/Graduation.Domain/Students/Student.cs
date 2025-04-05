using Graduation.Domain.AcademicGroups;
using Graduation.Domain.Common;
using Graduation.Domain.Users;

namespace Graduation.Domain.Students;

public class Student : Entity<Guid>
{
    public string? Comment { get; set; }
    public StudentStatus Status { get; set; }
    public Guid? AcademicGroupId { get; set; }
    public AcademicGroup? AcademicGroup { get; set; }
    public User User { get; set; }

    private Student(User user)
    {
        User = user;
    }

    public static Student Create(User user)
    {
        var student = new Student(user)
        {
            Status = StudentStatus.Active
        };

        return student;
    }

#pragma warning disable CS8618, CS9264
    private Student()
    {
    }
#pragma warning restore CS8618, CS9264
}