using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.GetTopics;

public class GetTopicsCommandHandler : IRequestHandler<GetTopicsCommand, GetTopicsCommandResult>
{
    private readonly UserManager<User> userManager;
    private readonly IMediator mediator;
    private readonly ICurrentYearProvider currentYearProvider;
    private readonly IAppDbContext dbContext;

    public GetTopicsCommandHandler(UserManager<User> userManager, IMediator mediator,
        ICurrentYearProvider currentYearProvider, IAppDbContext dbContext)
    {
        this.userManager = userManager;
        this.mediator = mediator;
        this.currentYearProvider = currentYearProvider;
        this.dbContext = dbContext;
    }

    public async Task<GetTopicsCommandResult> Handle(GetTopicsCommand request, CancellationToken cancellationToken)
    {
        var year = currentYearProvider.GetCurrentYear();
        var user = (await userManager.FindByIdAsync(request.UserId.ToString()))!;

        var roles = await userManager.GetRolesAsync(user);

        var topics = await GetTopicsForRoles(user, roles, year, request.IncludeOwnedTopics, cancellationToken);

        return new GetTopicsCommandResult(topics.ToList());
    }

    private async Task<IEnumerable<GetTopicsCommandTopic>> GetTopicsForRoles(
        User user,
        IList<string> roles,
        string year,
        bool includeOwnedTopics,
        CancellationToken cancellationToken)
    {
        var topicsQuery = from topic in dbContext.Topics
            join userRoleTopic in dbContext.UserRoleTopics on topic.Id equals userRoleTopic.TopicId
            join userRole in dbContext.UserRoles on userRoleTopic.UserId equals userRole.UserId
            join role in dbContext.Roles on userRole.RoleId equals role.Id
            where topic.Year == year && userRole.Year == year &&
                  ((roles.Contains(WellKnownRoles.Student) && role.Name != WellKnownRoles.Student) ||
                   (roles.Contains(WellKnownRoles.Supervisor) && role.Name != WellKnownRoles.Supervisor) ||
                   (includeOwnedTopics && topic.OwnerId == user.Id))
            select topic;

        var topics = await topicsQuery.Distinct()
            .Include(x => x.Owner)
            .Include(x => x.AcademicPrograms)
            .ToListAsync(cancellationToken: cancellationToken);

        var result = topics.Select(x =>
            new GetTopicsCommandTopic(x.Id,
                x.Name,
                x.Description,
                new GetTopicsCommandTopicOwner(x.OwnerId, x.Owner.FullName),
                x.AcademicPrograms.Select(ap => ap.Name).ToList()));

        return result;
    }
}