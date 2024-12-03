using MediatR;

namespace ScientificWork.UseCases.Users.GetProfileInfo;

public record GetProfileInfoQuery : IRequest<GetProfileInfoQueryResult>
{
    
}