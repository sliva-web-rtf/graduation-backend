using ScientificWork.Domain.Common;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.ScientificAreas;

/// <summary>
/// Scientific area.
/// </summary>
public class ScientificArea
{
    public Guid Id { get; set; }

    public string Name { get; private set; }

    private IList<ScientificAreaSubsection> scientificAreaSubsections;

    public IReadOnlyList<ScientificAreaSubsection> ScientificAreaSubsections => scientificAreaSubsections.AsReadOnly();

    public ScientificArea(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public void UpdateScientificAreaSubsections(List<ScientificAreaSubsection> scientificAreaSubsections)
    {
        this.scientificAreaSubsections = scientificAreaSubsections;
    }

    public ScientificArea()
    {

    }
}
