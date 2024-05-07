using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Users.UpdateStudentScientificPortfolio;

public class UpdateStudentScientificPortfolioCommandHandler : IRequestHandler<UpdateStudentScientificPortfolioCommand>
{
    private readonly IAppDbContext dbContext;
    private readonly UserManager<Student> userManager;
    private readonly ILoggedUserAccessor userAccessor;

    public UpdateStudentScientificPortfolioCommandHandler(IAppDbContext dbContext, UserManager<Student> userManager,
        ILoggedUserAccessor userAccessor)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(UpdateStudentScientificPortfolioCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId().ToString();
        var student = await userManager.FindByIdAsync(userId);
        if (student is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        student.UpdateScientificPortfolio(request.Degree, request.About, request.Year);

        if (request.ScientificAreaSubsections != null)
        {
            await UpdateScientificAreaSubsectionsAsync(student, request.ScientificAreaSubsections, cancellationToken);
        }

        if (request.ScientificInterests != null)
        {
            await UpdateScientificInterestsAsync(student, request.ScientificInterests, cancellationToken);
        }

        await userManager.UpdateAsync(student);
    }

    private async Task UpdateScientificAreaSubsectionsAsync(Student student, IList<string> scientificAreaSubsections,
        CancellationToken cancellationToken)
    {
        var selectedSubsections = await dbContext.ScientificAreaSubsections
            .Where(x => scientificAreaSubsections.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        student.UpdateScientificAreaSubsections(selectedSubsections);
    }

    private async Task UpdateScientificInterestsAsync(Student student, IList<string> scientificInterests,
        CancellationToken cancellationToken)
    {
        var selectedInterests = await dbContext.ScientificInterests
            .Where(x => scientificInterests.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        student.UpdateScientificInterest(selectedInterests);
    }
}
