using System.Text.RegularExpressions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ScientificWork.Infrastructure.Tools.Domain.Exceptions;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;
using ScientificWork.UseCases.CodeSender;
using ScientificWork.UseCases.Common.Settings.WebRoot;

namespace ScientificWork.UseCases.Professors.CreateProfessor;

public class CreateProfessorCommandHandler : IRequestHandler<CreateProfessorCommand, CreateProfessorCommandResult>
{
    private readonly UserManager<Professor> professorManager;
    private readonly UserManager<Student> studentManager;
    private readonly ILogger<CreateProfessorCommandHandler> logger;
    private readonly IHostingEnvironment environment;
    private readonly IEmailSender sender;
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateProfessorCommandHandler(
        UserManager<Professor> professorManager,
        UserManager<Student> studentManager,
        ILogger<CreateProfessorCommandHandler> logger,
        IHostingEnvironment environment,
        IEmailSender sender,
        IMediator mediator)
    {
        this.professorManager = professorManager;
        this.studentManager = studentManager;
        this.logger = logger;
        this.environment = environment;
        this.sender = sender;
        this.mediator = mediator;
    }

    public async Task<CreateProfessorCommandResult> Handle(
        CreateProfessorCommand request,
        CancellationToken cancellationToken)
    {
        ValidateEmail(request.Email);
        ValidatePassword(request.Password);

        if (await studentManager.FindByEmailAsync(request.Email) is not null ||
            await professorManager.FindByEmailAsync(request.Email) is not null)
        {
            logger.LogInformation($"User already created. Email: {request.Email}.");
            throw new DomainException("User already created.", 409);
        }

        var professor = Professor.Create(request.Email, WebRootConstants.DefaultAvatarPath);
        var result = await professorManager.CreateAsync(professor, request.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors
                .ToDictionary(grouping => grouping.Code, grouping => grouping.Description);
            throw new ValidationException(errors);
        }

        await professorManager.AddToRoleAsync(professor, nameof(Professor).ToLower());

        professor.UpdateLastLogin();
        await professorManager.UpdateAsync(professor);
        if (environment.IsProduction())
        {
            await sender.SendEmailAsync(request.Email, $"Your password is {request.Password}", "ScientificWork");
        }

        logger.LogInformation($"Professor created successfully. Id: {professor.Id}.");

        await mediator.Send(new SendConfirmationCodeCommand(professor, request.Email), cancellationToken);
        logger.LogInformation($"Professor confirm email code sent. Id: {professor.Id}.");

        return new CreateProfessorCommandResult(professor.Id);
    }

    private void ValidateEmail(string email)
    {
        var emailRegex = new Regex(@"[.\-_a-z0-9]+@([a-z0-9][\-a-z0-9]+\.)+[a-z]{2,6}", RegexOptions.IgnoreCase);
        var isMatch = emailRegex.Match(email);

        if (!isMatch.Success)
        {
            logger.LogInformation($"Invalid email format. Email: {email}.");
            throw new ValidationException("Invalid email format.");
        }

        if (email.Length is < 6 or > 255)
        {
            logger.LogInformation($"Email length is not valid. Email: {email}.");
            throw new ValidationException("Email length is not valid.");
        }
    }

    private void ValidatePassword(string password)
    {
        if (!password.Any(char.IsUpper) || !password.Any(char.IsLower))
        {
            logger.LogInformation("The password does not contain at least one uppercase and one lowercase letter.");
            throw new ValidationException("Password must contain at least one uppercase and one lowercase letter.");
        }

        if (!password.Any(char.IsDigit))
        {
            logger.LogInformation("The password does not contain at least one number.");
            throw new ValidationException("Password must contain at least one number.");
        }
    }
}