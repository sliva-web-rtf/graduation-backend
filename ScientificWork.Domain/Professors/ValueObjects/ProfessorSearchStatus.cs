using ScientificWork.Domain.Common;
using ScientificWork.Domain.Students.Enums;

namespace ScientificWork.Domain.Professors.ValueObjects;

public class ProfessorSearchStatus : ValueObject
{
    public SearchStatus Status { get; private set; }

    public int Limit { get; private set; }

    private ProfessorSearchStatus(
        SearchStatus status,
        int limit)
    {
        if (status is SearchStatus.Searching)
        {
            Limit = limit;
        }

        Status = status;
    }

    public static ProfessorSearchStatus Create(
        SearchStatus status,
        int limit)
    {
        return new ProfessorSearchStatus(status, limit);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Status;
        yield return Limit;
    }
}
