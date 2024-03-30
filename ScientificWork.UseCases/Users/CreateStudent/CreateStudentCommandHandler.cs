using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.DTOs;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Authentication;
using ScientificWork.UseCases.Users.AuthenticateUser;

namespace ScientificWork.UseCases.Users.CreateStudent;

/// <summary>
/// Create student command handler.
/// </summary>
public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentCommandResult>
{
    private readonly UserManager<Student> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly ITokenModelService tokenService;
    private readonly ILogger<CreateStudentCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateStudentCommandHandler(UserManager<Student> userManager,
        ILogger<CreateStudentCommandHandler> logger, SignInManager<User> signInManager,
        ITokenModelService tokenService)
    {
        this.userManager = userManager;
        this.logger = logger;
        this.signInManager = signInManager;
        this.tokenService = tokenService;
    }

    /// <inheritdoc />
    public async Task<CreateStudentCommandResult> Handle(CreateStudentCommand request,
        CancellationToken cancellationToken)
    {
        var student = Student.Create(request.Email);

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

        logger.LogInformation($"Student created successfully. Id: {student.Id}.");
        var token = await tokenService.Generate(student, false);

        return new CreateStudentCommandResult(student.Id, token);
    }
}
