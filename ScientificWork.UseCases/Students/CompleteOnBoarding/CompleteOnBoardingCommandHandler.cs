using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Students.CompleteOnBoarding;

public class CompleteOnBoardingCommandHandler : IRequestHandler<CompleteOnBoardingCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> userManager;
    private readonly IAppDbContext dbContext;

    public CompleteOnBoardingCommandHandler(ILoggedUserAccessor userAccessor, UserManager<Student> userManager,
        IAppDbContext dbContext)
    {
        this.userAccessor = userAccessor;
        this.userManager = userManager;
        this.dbContext = dbContext;
    }

    public async Task Handle(CompleteOnBoardingCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var user = await dbContext.Students
            .Include(s => s.ScientificInterests)
            .Include(s => s.ScientificAreaSubsections)
            .FirstOrDefaultAsync(
                student => student.Id == userId,
                cancellationToken: cancellationToken);
        if (user is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        if (!user.CompleteRegistration(out var errors))
        {
            var errorsDictionary = errors.ToDictionary(e => e, e => $"One of this stages not complete: {e}");
            throw new ValidationException(errorsDictionary);
        }

        await userManager.UpdateAsync(user);
    }
}
