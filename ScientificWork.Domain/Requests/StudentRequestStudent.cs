using ScientificWork.Domain.Requests.Enums;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.Requests;

public class StudentRequestStudent : Request
{
    public Guid StudentToId { get; private set; }

    public Student StudentTo { get; private set; }

    public Guid StudentFromId { get; private set; }

    public Student StudentFrom { get; private set; }

    public Guid ScientificWorkId { get; private set; }

    public ScientificWorks.ScientificWork ScientificWork { get; private set; }

    public RequestEnum RequestEnum;

    public StudentRequestStudent()
    {
    }

    public StudentRequestStudent(Student studentTo, Guid studentToId, Student student, Guid studentId,
        ScientificWorks.ScientificWork scientificWork, Guid scientificWorkId, RequestEnum requestEnum)
    {
        AddedAt = DateTime.UtcNow;
        StudentTo = studentTo;
        StudentToId = studentToId;
        StudentFrom = student;
        StudentFromId = studentId;
        ScientificWork = scientificWork;
        ScientificWorkId = scientificWorkId;
        RequestEnum = requestEnum;
    }
}
