using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Students.CreateStudent;

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
        var student = mapper.Map<Student>(request);

        if (request.ScientificAreaSubsections != null)
        {
            await UpdateScientificAreaSubsectionsAsync(student, request.ScientificAreaSubsections, cancellationToken);
        }

        if (request.ScientificInterests != null)
        {
            await UpdateScientificInterestsAsync(student, request.ScientificInterests, cancellationToken);
        }

        var result = await userManager.CreateAsync(student, request.Password);
        await userManager.AddToRoleAsync(student, nameof(Student).ToLower());
        if (result.Succeeded)
        {
            logger.LogInformation($"Student id: {student.Id}.");
        }
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
