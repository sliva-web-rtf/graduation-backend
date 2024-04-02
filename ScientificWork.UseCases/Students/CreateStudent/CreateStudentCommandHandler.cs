using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Students;

namespace ScientificWork.UseCases.Students.CreateStudent;

/// <summary>
/// Create student command handler.
/// </summary>
public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
{
    private readonly UserManager<Student> userManager;
    private readonly ILogger<CreateStudentCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateStudentCommandHandler(
        UserManager<Student> userManager,
        ILogger<CreateStudentCommandHandler> logger)
    {
        this.userManager = userManager;
        this.logger = logger;
    }

    /// <inheritdoc />
    public async Task Handle(CreateStudentCommand request,
        CancellationToken cancellationToken)
    {
        if (await userManager.FindByEmailAsync(request.Email) is not null)
        {
            logger.LogInformation($"Student already created. Email: {request.Email}.");
            return;
        }
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
    }
}
