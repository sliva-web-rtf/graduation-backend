using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.Favorites;

public class StudentFavoriteProfessor : FavoriteBase
{
    public Guid StudentId { get; }

    public Student Student { get; }

    public Guid ProfessorId { get; }

    public Professor Professor { get; }

    private StudentFavoriteProfessor(
        Guid studentId,
        Guid professorId,
        DateTime addedAt)
    {
        StudentId = studentId;
        ProfessorId = professorId;
        AddedAt = addedAt;
        IsActive = true;
    }

    public static StudentFavoriteProfessor Create(
        Guid studentId,
        Guid professorId)
    {
        return new StudentFavoriteProfessor(professorId, studentId, DateTime.UtcNow);
    }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return StudentId;
        yield return ProfessorId;
    }
}
