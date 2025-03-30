using MediatR;

namespace Graduation.Application.Users.GetUserById;

public record GetUserByIdQuery() : IRequest<UserDetailsDto>
{
    public Guid UserId { get; init; }
}
