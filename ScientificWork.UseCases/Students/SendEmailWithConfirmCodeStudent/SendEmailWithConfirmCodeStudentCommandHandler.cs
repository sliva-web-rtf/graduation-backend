using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;
using ScientificWork.UseCases.Students.CreateStudent;

namespace ScientificWork.UseCases.Students.SendEmailWithConfirmCodeStudent;

public class SendEmailWithConfirmCodeStudentCommandHandler : IRequestHandler<SendEmailWithConfirmCodeStudentCommand,
    SendEmailWithConfirmCodeStudentCommandResult>
{
    private readonly UserManager<Student> studentManager;
    private readonly ILogger<CreateStudentCommandHandler> logger;
    private readonly IEmailSender sender;

    /// <summary>
    /// Constructor.
    /// </summary>
    public SendEmailWithConfirmCodeStudentCommandHandler(
        UserManager<Student> studentManager,
        ILogger<CreateStudentCommandHandler> logger,
        IEmailSender sender)
    {
        this.studentManager = studentManager;
        this.logger = logger;
        this.sender = sender;
    }

    public async Task<SendEmailWithConfirmCodeStudentCommandResult> Handle(
        SendEmailWithConfirmCodeStudentCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Email);
        ArgumentException.ThrowIfNullOrEmpty(request.StudentId);

        var student = await GetStudentByIdAsync(request.StudentId, cancellationToken);
        var confirmEmailCode = await studentManager.GenerateEmailConfirmationTokenAsync(student);
        await sender.SendEmailAsync(request.Email, $"Ваш новый код для подтверждения регистрации: {confirmEmailCode}",
            "Ваш новый код");
        logger.LogInformation($"Student confirm email code sent. Id: {student.Id}.");

        return await Task.FromResult(new SendEmailWithConfirmCodeStudentCommandResult { Succeeded = true });
    }

    private async Task<Student> GetStudentByIdAsync(string id, CancellationToken cancellationToken)
    {
        var student = await studentManager.Users
            .Where(x => x.Id.ToString() == id)
            .FirstAsync(cancellationToken);

        if (!await studentManager.IsInRoleAsync(student, nameof(Student).ToLower()))
        {
            throw new Exception();
        }

        return student;
    }
}