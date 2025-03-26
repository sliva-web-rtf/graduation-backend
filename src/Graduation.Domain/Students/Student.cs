using Graduation.Domain.Users;

namespace Graduation.Domain.Students;

public class Student : User
{
    public string? Comment { get; set; }
    public StudentStatus Status { get; set; }
    public Guid AcademicGroupId { get; set; }
    
    protected Student(Guid id) : base(id)
    {
    }
}