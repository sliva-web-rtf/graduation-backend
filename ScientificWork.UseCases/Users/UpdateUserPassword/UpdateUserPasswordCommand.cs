using MediatR;

namespace ScientificWork.UseCases.Users.UpdateUserPassword;

public record UpdateUserPasswordCommand : IRequest
{
    public string? CurrentPassword { get; init; }

    public string? NewPassword { get; init; }
}
