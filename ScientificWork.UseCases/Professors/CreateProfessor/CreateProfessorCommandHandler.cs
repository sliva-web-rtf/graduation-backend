using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Professors;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;
using ScientificWork.UseCases.Students.CreateStudent;

namespace ScientificWork.UseCases.Professors.CreateProfessor;

public class CreateProfessorCommandHandler : IRequestHandler<CreateProfessorCommand>
{
    private readonly UserManager<Professor> userManager;
    private readonly ILogger<CreateStudentCommandHandler> logger;
    private readonly IHostingEnvironment environment;
    private readonly IEmailSender sender;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateProfessorCommandHandler(
        UserManager<Professor> userManager,
        ILogger<CreateStudentCommandHandler> logger,
        IHostingEnvironment environment,
        IEmailSender sender)
    {
        this.userManager = userManager;
        this.logger = logger;
        this.environment = environment;
        this.sender = sender;
    }

    public async Task Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
    {
        if (await userManager.FindByEmailAsync(request.Email) is not null)
        {
            logger.LogInformation($"Professor already created. Email: {request.Email}.");
            return;
        }
        var professor = Professor.Create(request.Email);

        var result = await userManager.CreateAsync(professor, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors
                .ToDictionary(grouping => grouping.Code, grouping => grouping.Description);
            throw new ValidationException(errors);
        }

        await userManager.AddToRoleAsync(professor, nameof(Professor).ToLower());

        professor.UpdateLastLogin();
        await userManager.UpdateAsync(professor);
        if (environment.IsProduction())
        {
            await sender.SendEmailAsync(request.Email, $"Your password is {request.Password}", "ScientificWork");
        }

        logger.LogInformation($"Professor created successfully. Id: {professor.Id}.");
    }
}
