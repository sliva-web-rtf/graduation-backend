using Graduation.Application.Interfaces.Services;
using Graduation.Application.Topics.GetStudentTopics;
using Graduation.Application.Topics.GetSupervisorTopics;
using Graduation.Domain;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Graduation.Application.Topics.GetTopics;

public class GetTopicsCommandHandler : IRequestHandler<GetTopicsCommand, GetTopicsCommandResult>
{
    private readonly UserManager<User> userManager;
    private readonly IMediator mediator;
    private readonly ICurrentYearProvider currentYearProvider;

    public GetTopicsCommandHandler(UserManager<User> userManager, IMediator mediator,
        ICurrentYearProvider currentYearProvider)
    {
        this.userManager = userManager;
        this.mediator = mediator;
        this.currentYearProvider = currentYearProvider;
    }

    public async Task<GetTopicsCommandResult> Handle(GetTopicsCommand request, CancellationToken cancellationToken)
    {
        var year = currentYearProvider.GetCurrentYear();
        var user = (await userManager.FindByIdAsync(request.UserId.ToString()))!;

        var roles = await userManager.GetRolesAsync(user);

        var topics = new List<GetTopicsCommandTopic>();
        foreach (var role in roles)
        {
            var roleTopics = await GetTopicsForRole(user, role, year);
            topics.AddRange(roleTopics);
        }

        return new GetTopicsCommandResult(topics.Distinct().ToList());
    }

    private async Task<IEnumerable<GetTopicsCommandTopic>> GetTopicsForRole(User user, string role, string year)
    {
        return role switch
        {
            WellKnownRoles.Student => await mediator.Send(new GetStudentTopicsCommand(user, year)),
            WellKnownRoles.Supervisor => await mediator.Send(new GetSupervisorTopicsCommand(user, year)),
            _ => Array.Empty<GetTopicsCommandTopic>()
        };
    }
}