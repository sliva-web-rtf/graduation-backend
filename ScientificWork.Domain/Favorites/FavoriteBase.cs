using ScientificWork.Domain.Common;

namespace ScientificWork.Domain.Favorites;

public abstract class FavoriteBase : Entity
{
    public DateTime AddedAt { get; protected set; }

    public bool IsActive { get; protected set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return AddedAt;
        yield return IsActive;
        foreach (var id in GetFavoriteEntitiesIds())
        {
            yield return id;
        }
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    protected abstract IEnumerable<object?> GetFavoriteEntitiesIds();
}
