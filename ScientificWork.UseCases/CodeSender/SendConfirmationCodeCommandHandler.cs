using MediatR;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;

namespace ScientificWork.UseCases.CodeSender;

public class SendConfirmationCodeCommandHandler(IEmailSender sender, UserManager<User> userManager)
    : IRequestHandler<SendConfirmationCodeCommand>
{
    public async Task Handle(SendConfirmationCodeCommand request, CancellationToken cancellationToken)
    {
        var confirmEmailCode = await userManager.GenerateEmailConfirmationTokenAsync(request.User);
        await sender.SendEmailAsync(request.Email, $"Ваш код для подтверждения регистрации: {confirmEmailCode}", "Ваш код");
    }
}