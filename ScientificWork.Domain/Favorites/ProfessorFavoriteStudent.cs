using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace ScientificWork.Domain.Favorites;

public class ProfessorFavoriteStudent : FavoriteBase
{
    public Guid ProfessorId { get; }

    public Professor? Professor { get; }

    public Guid StudentId { get; }

    public Student? Student { get; }

    private ProfessorFavoriteStudent(
        Guid professorId,
        Guid studentId,
        DateTime addedAt)
    {
        ProfessorId = professorId;
        StudentId = studentId;
        AddedAt = addedAt;
        IsActive = true;
    }

    public static ProfessorFavoriteStudent Create(
        Guid professorId,
        Guid studentId)
    {
        return new ProfessorFavoriteStudent(professorId, studentId, DateTime.UtcNow);
    }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return ProfessorId;
        yield return StudentId;
    }
}
