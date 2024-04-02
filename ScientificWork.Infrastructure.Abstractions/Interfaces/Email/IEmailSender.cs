using ScientificWork.Domain.Enums.Email;

namespace ScientificWork.Infrastructure.Abstractions.Interfaces.Email;

public interface IEmailSender
{
    public Task<EmailResult> SendEmailAsync(
        string emailAddress,
        string message,
        string subject);
}
