using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;
using ScientificWork.UseCases.Common.Settings.WebRoot;

namespace ScientificWork.UseCases.Students.CreateStudent;

/// <summary>
/// Create student command handler.
/// </summary>
public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentCommandResult>
{
    private readonly UserManager<Student> userManager;
    private readonly ILogger<CreateStudentCommandHandler> logger;
    private readonly IHostingEnvironment environment;
    private readonly IEmailSender sender;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateStudentCommandHandler(
        UserManager<Student> userManager,
        ILogger<CreateStudentCommandHandler> logger,
        IHostingEnvironment environment,
        IEmailSender sender)
    {
        this.userManager = userManager;
        this.logger = logger;
        this.environment = environment;
        this.sender = sender;
    }

    /// <inheritdoc />
    public async Task<CreateStudentCommandResult> Handle(CreateStudentCommand request,
        CancellationToken cancellationToken)
    {
        if (await userManager.FindByEmailAsync(request.Email) is not null)
        {
            logger.LogInformation($"Student already created. Email: {request.Email}.");
            return new CreateStudentCommandResult(Guid.Empty);
        }
        var student = Student.Create(request.Email, WebRootConstants.DefaultAvatarPath);

        var result = await userManager.CreateAsync(student, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors
                .ToDictionary(grouping => grouping.Code, grouping => grouping.Description);
            throw new ValidationException(errors);
        }

        await userManager.AddToRoleAsync(student, nameof(Student).ToLower());

        student.UpdateLastLogin();
        await userManager.UpdateAsync(student);
        if (environment.IsProduction())
        {
            await sender.SendEmailAsync(request.Email, $"Your password is {request.Password}", "ScientificWork");
        }

        logger.LogInformation($"Student created successfully. Id: {student.Id}.");

        return new CreateStudentCommandResult(student.Id);
    }
}
