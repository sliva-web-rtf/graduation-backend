namespace ScientificWork.Domain.Favorites;

public class StudentFavoriteScientificWork : FavoriteBase
{
    public Guid StudentId { get; }

    public Guid ScientificWorkId { get; }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return StudentId;
        yield return ScientificWorkId;
    }
}
