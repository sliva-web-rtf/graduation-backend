using System.Text.RegularExpressions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ScientificWork.UseCases.Common.Exceptions;
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
        ValidateEmail(request.Email);
        ValidatePassword(request.Password);
        
        if (await userManager.FindByEmailAsync(request.Email) is not null)
        {
            logger.LogInformation($"Student already created. Email: {request.Email}.");
            throw new DomainException("Student already created.", 409);
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
    
    private void ValidateEmail(string email)
    {
        var emailRegex = new Regex( @"[.\-_a-z0-9]+@([a-z0-9][\-a-z0-9]+\.)+[a-z]{2,6}", RegexOptions.IgnoreCase);
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
