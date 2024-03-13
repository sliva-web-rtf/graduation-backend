using ScientificWork.Domain.Common;
using ScientificWork.Domain.Students.Enums;

namespace ScientificWork.Domain.Students.ValueObjects;

public class StudentSearchStatus : ValueObject
{
    public SearchStatus Status { get; private set; }

    public bool CommandSearching { get; private set; }

    public bool ProfessorSearching { get; private set; }

    private StudentSearchStatus(
        SearchStatus status,
        bool commandSearching,
        bool professorSearching)
    {
        if (status is SearchStatus.Searching)
        {
            CommandSearching = commandSearching;
            ProfessorSearching = professorSearching;
        }

        Status = status;
    }

    public static StudentSearchStatus Create(
        SearchStatus status,
        bool commandSearching,
        bool professorSearching)
    {
        return new StudentSearchStatus(status, commandSearching, professorSearching);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Status;
        yield return CommandSearching;
        yield return ProfessorSearching;
    }
}
