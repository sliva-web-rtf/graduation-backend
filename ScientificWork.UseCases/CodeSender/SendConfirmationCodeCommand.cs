using MediatR;
using ScientificWork.Domain.Users;

namespace ScientificWork.UseCases.CodeSender;

public class SendConfirmationCodeCommand(User user, string email) : IRequest
{
    public User User { get; init; } = user;
    public string Email { get; init; } = email;
}