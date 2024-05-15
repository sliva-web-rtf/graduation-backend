using ScientificWork.Domain.Students;
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace ScientificWork.Domain.Favorites;

public class StudentFavoriteStudent : FavoriteBase
{
    public Guid StudentId { get; }

    public Student? Student { get; }

    public Guid FavoriteStudentId { get; }

    public Student? FavoriteStudent { get; }

    private StudentFavoriteStudent(
        Guid studentId,
        Guid favoriteStudentId,
        DateTime addedAt)
    {
        StudentId = studentId;
        FavoriteStudentId = favoriteStudentId;
        AddedAt = addedAt;
        IsActive = true;
    }

    public static StudentFavoriteStudent Create(
        Guid studentId,
        Guid favoriteStudentId)
    {
        return new StudentFavoriteStudent(studentId, favoriteStudentId, DateTime.UtcNow);
    }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return StudentId;
        yield return FavoriteStudentId;
    }
}
