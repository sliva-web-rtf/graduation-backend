using MediatR;

namespace ScientificWork.UseCases.ScientificWorks.CreateScientificWork;

public class CreateScientificWorkCommand : IRequest
{
    required public string Name { get; init; }

    required public string Description { get; init; }

    required public int Limit { get; init; } = 1;

    required public string Result { get; init; }

    required public IList<string> ScientificAreaSubsections { get; init; }

    required public IList<string> ScientificInterests { get; init; }

    required public bool IsEducator { get; init; }
}
