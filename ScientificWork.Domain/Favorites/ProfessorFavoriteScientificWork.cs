namespace ScientificWork.Domain.Favorites;

public class ProfessorFavoriteScientificWork : FavoriteBase
{
    public Guid ProfessorId { get; }

    public Guid ScientificWorkId { get; }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return ProfessorId;
        yield return ScientificWorkId;
    }
}
