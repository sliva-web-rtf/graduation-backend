using ScientificWork.Domain.Common;

namespace ScientificWork.Domain.Favorites;

public abstract class FavoriteBase : Entity
{
    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CreatedAt;
        yield return IsActive;
        foreach (var id in GetFavoriteEntitiesIds())
        {
            yield return id;
        }
    }

    protected abstract IEnumerable<object?> GetFavoriteEntitiesIds();
}
