using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.Favorites;

public class StudentFavoriteScientificWork : FavoriteBase
{
    public Guid StudentId { get; }

    public Student Student { get; }

    public Guid ScientificWorkId { get; }

    public ScientificWorks.ScientificWork ScientificWork { get; }

    private StudentFavoriteScientificWork(
        Guid studentId,
        Guid scientificWorkId,
        DateTime addedAt)
    {
        StudentId = studentId;
        ScientificWorkId = scientificWorkId;
        AddedAt = addedAt;
        IsActive = true;
    }

    public static StudentFavoriteScientificWork Create(
        Guid studentId,
        Guid scientificWorkId)
    {
        return new StudentFavoriteScientificWork(studentId, scientificWorkId, DateTime.UtcNow);
    }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return StudentId;
        yield return ScientificWorkId;
    }
}
