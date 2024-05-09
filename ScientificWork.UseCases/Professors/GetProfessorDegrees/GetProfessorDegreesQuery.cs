using MediatR;

namespace ScientificWork.UseCases.Professors.GetProfessorDegrees;

public class GetProfessorDegreesQuery : IRequest<IList<string>>
{
    /// <summary>
    /// Search.
    /// </summary>
    required public string Search { get; init; } = "";
}
