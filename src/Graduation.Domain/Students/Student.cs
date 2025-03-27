using Graduation.Domain.Users;

namespace Graduation.Domain.Students;

public class Student : User
{
    public string? Comment { get; set; }
    public StudentStatus Status { get; set; }
    public Guid AcademicGroupId { get; set; }

    private Student(Guid id) : base(id)
    {
    }

    public static Student Create(Guid id,
        string email,
        string firstName,
        string lastName,
        string patronymic,
        string? contacts,
        string? about)
    {
        var student = new Student(id);
        student.UpdateProfileInfo(email, firstName, lastName, patronymic, contacts, about);
        return student;
    }
}