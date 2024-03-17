using MediatR;

namespace ScientificWork.UseCases.ScientificWorks.CreateScientificWork;

public class CreateScientificWorkCommand : IRequest
{
    required public string Name { get; init; }

    required public string Title { get; init; }

    required public int Limit { get; init; } = 1;

    required public string Problem { get; init; }

    required public IList<string> ScientificAreaSubsections { get; init; }

    required public IList<string> ScientificInterests { get; init; }
}
