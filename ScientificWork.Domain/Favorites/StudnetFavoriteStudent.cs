namespace ScientificWork.Domain.Favorites;

public class StudnetFavoriteStudent : FavoriteBase
{
    public Guid StudentId { get; }

    public Guid FavoriteStudentId { get; }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return StudentId;
        yield return FavoriteStudentId;
    }
}
