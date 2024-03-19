using MediatR;

namespace ScientificWork.UseCases.ScientificWorks.UpdateScientificWork;

public class UpdateScientificWorkCommand : IRequest
{
    required public Guid Id { get; init; }

    required public string Name { get; init; }

    required public string Title { get; init; }

    public int Limit { get; init; }

    required public string Problem { get; init; }

    required public IList<string> ScientificAreaSubsections { get; init; }

    required public IList<string> ScientificInterests { get; init; }
}
