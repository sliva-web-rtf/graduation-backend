using MediatR;

namespace ScientificWork.UseCases.Users.GetProfileInfo;

public record GetProfileInfoCommand : IRequest<GetProfileInfoCommandResult>
{
    
}