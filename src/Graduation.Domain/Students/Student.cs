using Graduation.Domain.AcademicGroups;
using Graduation.Domain.Commissions;
using Graduation.Domain.Common;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Users;

namespace Graduation.Domain.Students;

public class Student : Entity<Guid>
{
    private Student(User user)
    {
        User = user;
    }

#pragma warning disable CS8618, CS9264
    private Student()
    {
    }
#pragma warning restore CS8618, CS9264
    public string? Comment { get; set; }
    public StudentStatus Status { get; set; }
    public Guid? AcademicGroupId { get; set; }
    public AcademicGroup? AcademicGroup { get; set; }
    public User? User { get; set; }
    public QualificationWork? QualificationWork { get; set; }
    
    public List<CommissionStudent> CommissionStudents { get; set; }


    public static Student Create(User user)
    {
        var student = new Student(user)
        {
            Status = StudentStatus.Active
        };

        return student;
    }
}