using ScientificWork.Domain.Common;
using ScientificWork.Domain.Students.Enums;

namespace ScientificWork.Domain.Students.ValueObjects;

public class StudentSearchStatus : ValueObject
{
    public SearchStatus Status { get; private set; }

    public bool CommandSearching { get; private set; }

    public bool ProfessorSearching { get; private set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Status;
        yield return CommandSearching;
        yield return ProfessorSearching;
    }
}
