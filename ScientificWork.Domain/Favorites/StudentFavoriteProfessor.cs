namespace ScientificWork.Domain.Favorites;

public class StudentFavoriteProfessor : FavoriteBase
{
    public Guid StudentId { get; }

    public Guid ProfessorId { get; }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return StudentId;
        yield return ProfessorId;
    }
}
