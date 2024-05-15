namespace ScientificWork.Domain.ScientificAreas;

/// <summary>
/// Scientific area.
/// </summary>
public class ScientificArea
{
    public Guid Id { get; set; }

    public string Name { get; private set; }

    private List<ScientificAreaSubsection> scientificAreaSubsections = new();

    public IReadOnlyList<ScientificAreaSubsection> ScientificAreaSubsections => scientificAreaSubsections.AsReadOnly();

    public ScientificArea(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public void UpdateScientificAreaSubsections(List<ScientificAreaSubsection> newScientificAreaSubsections)
    {
        this.scientificAreaSubsections = newScientificAreaSubsections;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ScientificArea()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }
}
