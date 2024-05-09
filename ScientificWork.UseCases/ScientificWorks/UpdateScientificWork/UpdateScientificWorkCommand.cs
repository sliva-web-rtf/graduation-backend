using MediatR;

namespace ScientificWork.UseCases.ScientificWorks.UpdateScientificWork;

public class UpdateScientificWorkCommand : IRequest
{
    required public Guid Id { get; init; }

    required public string Name { get; init; }

    required public string Description { get; init; }

    public int Limit { get; init; }

    required public string Result { get; init; }

    required public IList<string> ScientificAreaSubsections { get; init; }

    required public IList<string> ScientificInterests { get; init; }
}
