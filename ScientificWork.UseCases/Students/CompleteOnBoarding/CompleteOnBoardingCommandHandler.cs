using MediatR;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Students.CompleteOnBoarding;

public class CompleteOnBoardingCommandHandler : IRequestHandler<CompleteOnBoardingCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> userManager;

    public CompleteOnBoardingCommandHandler(ILoggedUserAccessor userAccessor, UserManager<Student> userManager)
    {
        this.userAccessor = userAccessor;
        this.userManager = userManager;
    }

    public async Task Handle(CompleteOnBoardingCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var user = await userManager.FindByIdAsync(userId.ToString());
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
