using MediatR;

namespace ScientificWork.UseCases.Users.GetUserById;

/// <summary>
/// Get user details by identifier.
/// </summary>
public record GetUserByIdQuery : IRequest<UserDetailsDto>
{
    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }
}
