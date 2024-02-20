namespace ScientificWork.Domain.Favorites;

public class ProfessorFavoriteStudent : FavoriteBase
{
    public Guid ProfessorId { get; }

    public Guid StudentId { get; }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return ProfessorId;
        yield return StudentId;
    }
}
