using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Professors;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Users.UpdateProfessorScientificPortfolio;

public class UpdateProfessorScientificPortfolioCommandHandler
    : IRequestHandler<UpdateProfessorScientificPortfolioCommand>
{
    private readonly IAppDbContext dbContext;
    private readonly UserManager<Professor> userManager;
    private readonly ILoggedUserAccessor userAccessor;

    public UpdateProfessorScientificPortfolioCommandHandler(IAppDbContext dbContext, UserManager<Professor> userManager,
        ILoggedUserAccessor userAccessor)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(UpdateProfessorScientificPortfolioCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var professor = await userManager.Users.Where(u => u.Id == userId)
            .Include(u => u.ScientificAreaSubsections)
            .Include(u => u.ScientificInterests)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (professor is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        professor.UpdateScientificPortfolio(
            request.Degree,
            request.Post,
            request.About,
            request.Address,
            request.WorkExperienceYears,
            request.ScopusUri,
            request.RISCUri,
            request.URPUri);

        if (request.ScientificAreaSubsections != null)
        {
            await UpdateScientificAreaSubsectionsAsync(professor, request.ScientificAreaSubsections, cancellationToken);
        }

        if (request.ScientificInterests != null)
        {
            await UpdateScientificInterestsAsync(professor, request.ScientificInterests, cancellationToken);
        }

        await userManager.UpdateAsync(professor);
    }

    private async Task UpdateScientificAreaSubsectionsAsync(Professor professor,
        IList<string> scientificAreaSubsections,
        CancellationToken cancellationToken)
    {
        var selectedSubsections = await dbContext.ScientificAreaSubsections
            .Where(x => scientificAreaSubsections.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        professor.UpdateScientificAreaSubsections(selectedSubsections);
    }

    private async Task UpdateScientificInterestsAsync(Professor professor, IList<string> scientificInterests,
        CancellationToken cancellationToken)
    {
        var selectedInterests = await dbContext.ScientificInterests
            .Where(x => scientificInterests.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        professor.UpdateScientificInterest(selectedInterests);
    }
}
