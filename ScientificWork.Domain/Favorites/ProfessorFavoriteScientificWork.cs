using ScientificWork.Domain.Professors;
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace ScientificWork.Domain.Favorites;

public class ProfessorFavoriteScientificWork : FavoriteBase
{
    public Guid ProfessorId { get; }

    public Professor? Professor { get; }

    public Guid ScientificWorkId { get; }

    public ScientificWorks.ScientificWork? ScientificWork { get; }

    private ProfessorFavoriteScientificWork(
        Guid professorId,
        Guid scientificWorkId,
        DateTime addedAt)
    {
        ProfessorId = professorId;
        ScientificWorkId = scientificWorkId;
        AddedAt = addedAt;
        IsActive = true;
    }

    public static ProfessorFavoriteScientificWork Create(
        Guid professorId,
        Guid scientificWorkId)
    {
        return new ProfessorFavoriteScientificWork(professorId, scientificWorkId, DateTime.UtcNow);
    }

    protected override IEnumerable<object?> GetFavoriteEntitiesIds()
    {
        yield return ProfessorId;
        yield return ScientificWorkId;
    }
}
