using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Requests.Enums;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.Requests;

public class StudentRequestProfessor : Request
{
    public Guid ProfessorId { get; private set; }

    public Professor Professor { get; private set; }

    public Guid StudentId { get; private set; }

    public Student Student { get; private set; }

    public Guid ScientificWorkId { get; private set; }

    public ScientificWorks.ScientificWork ScientificWork { get; private set; }

    public RequestEnum RequestEnum;

    public StudentRequestProfessor(Professor professor, Guid professorId, Student student, Guid studentId,
        ScientificWorks.ScientificWork scientificWork, Guid scientificWorkId, RequestEnum requestEnum, string message)
    {
        AddedAt = DateTime.UtcNow;
        Professor = professor;
        ProfessorId = professorId;
        Student = student;
        StudentId = studentId;
        ScientificWork = scientificWork;
        ScientificWorkId = scientificWorkId;
        RequestEnum = requestEnum;
        Message = message;
    }
    
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public StudentRequestProfessor()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}
