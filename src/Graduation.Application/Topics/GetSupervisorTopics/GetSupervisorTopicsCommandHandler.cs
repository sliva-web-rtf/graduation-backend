using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Topics.GetTopics;
using Graduation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.GetSupervisorTopics;

public class GetSupervisorTopicsCommandHandler : IRequestHandler<GetSupervisorTopicsCommand, List<GetTopicsCommandTopic>>
{
    private readonly IAppDbContext dbContext;

    public GetSupervisorTopicsCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<GetTopicsCommandTopic>> Handle(GetSupervisorTopicsCommand request, CancellationToken cancellationToken)
    {
        var topicsQuery = from topic in dbContext.Topics
            join userRoleTopic in dbContext.UserRoleTopics on topic.Id equals userRoleTopic.TopicId
            join userRole in dbContext.UserRoles on userRoleTopic.UserId equals userRole.UserId
            join role in dbContext.Roles on userRole.RoleId equals role.Id
            where topic.Year == request.Year && userRole.Year == request.Year && role.Name != WellKnownRoles.Supervisor
            select topic;

        var topics = await topicsQuery.Distinct().ToListAsync(cancellationToken);

        return topics.Select(x => new GetTopicsCommandTopic(x.Id, x.Name, x.Description, x.Result)).ToList();
    }
}