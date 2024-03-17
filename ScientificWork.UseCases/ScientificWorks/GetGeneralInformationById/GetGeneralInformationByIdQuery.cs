using MediatR;

namespace ScientificWork.UseCases.ScientificWorks.GetGeneralInformationById;

public class GetGeneralInformationByIdQuery : IRequest<GetGeneralInformationByIdResult>
{
    /// <summary>
    /// Scientific work id.
    /// </summary>
    required public Guid Id { get; init; }
}
