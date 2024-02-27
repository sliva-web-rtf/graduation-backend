using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Students.Common.Exceptions;

namespace ScientificWork.UseCases.Students.OnBoarding.CreateStudent;

/// <summary>
/// Create student command handler.
/// </summary>
public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
{
    private readonly IMapper mapper;
    private readonly IAppDbContext dbContext;
    private readonly UserManager<Student> userManager;
    private readonly ILogger<CreateStudentCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateStudentCommandHandler(IMapper mapper, IAppDbContext dbContext, UserManager<Student> userManager,
        ILogger<CreateStudentCommandHandler> logger)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
        this.userManager = userManager;
        this.logger = logger;
    }

    /// <inheritdoc />
    public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = Student.Create(
            request.FirstName,
            request.LastName,
            request.Patronymic,
            request.Email,
            request.PhoneNumber,
            request.Сontacts);

        // TODO: move to another command
        // if (request.ScientificAreaSubsections != null)
        // {
        //     await UpdateScientificAreaSubsectionsAsync(student, request.ScientificAreaSubsections, cancellationToken);
        // }
        //
        // if (request.ScientificInterests != null)
        // {
        //     await UpdateScientificInterestsAsync(student, request.ScientificInterests, cancellationToken);
        // }

        var result = await userManager.CreateAsync(student, request.Password);
        if (result.Succeeded)
        {
            logger.LogInformation($"Student id: {student.Id}.");
            await userManager.AddToRoleAsync(student, nameof(Student).ToLower());
        }

        var errors = result.Errors
            .ToDictionary(grouping => grouping.Code, grouping => grouping.Description);
        throw new ValidationException(errors);
    }

    private async Task UpdateScientificAreaSubsectionsAsync(Student student, IList<string> scientificAreaSubsections,
        CancellationToken cancellationToken)
    {
        var selectedSubsections = await dbContext.ScientificAreaSubsections
            .Where(x => scientificAreaSubsections.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        student.AddScientificAreaSubsections(selectedSubsections);
    }

    private async Task UpdateScientificInterestsAsync(Student student, IList<string> scientificInterests,
        CancellationToken cancellationToken)
    {
        var selectedInterests = await dbContext.ScientificInterests
            .Where(x => scientificInterests.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        student.AddScientificInterest(selectedInterests);
    }
}
