using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificWork.Domain.Students;
using ScientificWork.UseCases.CodeSender;
using ScientificWork.UseCases.Students.CreateStudent;

namespace ScientificWork.UseCases.Students.SendEmailWithConfirmCodeStudent;

public class SendEmailWithConfirmCodeStudentCommandHandler : IRequestHandler<SendEmailWithConfirmCodeStudentCommand,
    SendEmailWithConfirmCodeStudentCommandResult>
{
    private readonly UserManager<Student> studentManager;
    private readonly ILogger<CreateStudentCommandHandler> logger;
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public SendEmailWithConfirmCodeStudentCommandHandler(
        UserManager<Student> studentManager,
        ILogger<CreateStudentCommandHandler> logger,
        IMediator mediator)
    {
        this.studentManager = studentManager;
        this.logger = logger;
        this.mediator = mediator;
    }

    public async Task<SendEmailWithConfirmCodeStudentCommandResult> Handle(
        SendEmailWithConfirmCodeStudentCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Email);
        ArgumentException.ThrowIfNullOrEmpty(request.StudentId);

        var student = await GetStudentByIdAsync(request.StudentId, cancellationToken);
        await mediator.Send(new SendConfirmationCodeCommand(student, request.Email), cancellationToken);
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