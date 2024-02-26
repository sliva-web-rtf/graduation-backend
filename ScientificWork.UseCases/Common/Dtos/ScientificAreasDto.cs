namespace ScientificWork.UseCases.Common.Dtos;

public class ScientificAreasDto
{
    required public string Section { get; init; }

    required public IList<string> Subsections { get; init; }
}
