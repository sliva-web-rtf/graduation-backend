using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificWork.Domain.Professors;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;
using ScientificWork.UseCases.Professors.CreateProfessor;

namespace ScientificWork.UseCases.Professors.SendEmailWithConfirmCodeProfessor;

public class SendEmailWithConfirmCodeProfessorCommandHandler : IRequestHandler<SendEmailWithConfirmCodeProfessorCommand,
    SendEmailWithConfirmCodeProfessorCommandResult>
{
    private readonly UserManager<Professor> professorManager;
    private readonly ILogger<CreateProfessorCommandHandler> logger;
    private readonly IEmailSender sender;

    /// <summary>
    /// Constructor.
    /// </summary>
    public SendEmailWithConfirmCodeProfessorCommandHandler(
        UserManager<Professor> professorManager,
        ILogger<CreateProfessorCommandHandler> logger,
        IEmailSender sender)
    {
        this.professorManager = professorManager;
        this.logger = logger;
        this.sender = sender;
    }

    public async Task<SendEmailWithConfirmCodeProfessorCommandResult> Handle(
        SendEmailWithConfirmCodeProfessorCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Email);
        ArgumentException.ThrowIfNullOrEmpty(request.ProfessorId);

        var professor = await GetProfessorByIdAsync(request.ProfessorId, cancellationToken);
        var confirmEmailCode = await professorManager.GenerateEmailConfirmationTokenAsync(professor);
        await sender.SendEmailAsync(request.Email, $"Ваш новый код для подтверждения регистрации: {confirmEmailCode}",
            "Ваш новый код");
        logger.LogInformation($"Professor confirm email code sent. Id: {professor.Id}.");

        return await Task.FromResult(new SendEmailWithConfirmCodeProfessorCommandResult { Succeeded = true });
    }

    private async Task<Professor> GetProfessorByIdAsync(string id, CancellationToken cancellationToken)
    {
        var professor = await professorManager.Users
            .Where(x => x.Id.ToString() == id)
            .FirstAsync(cancellationToken);

        if (!await professorManager.IsInRoleAsync(professor, nameof(Professor).ToLower()))
        {
            throw new Exception();
        }

        return professor;
    }
}