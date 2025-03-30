using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.GetTopics;

public class GetTopicsQueryHandler : IRequestHandler<GetTopicsQuery, GetTopicsQueryResult>
{
    private record GetTopicsData(
        User User,
        IList<string> Roles,
        string Year,
        bool IncludeOwnedTopics,
        int Page,
        int Size,
        string Query,
        CancellationToken CancellationToken);

    private readonly UserManager<User> userManager;
    private readonly ICurrentYearProvider currentYearProvider;
    private readonly IAppDbContext dbContext;

    public GetTopicsQueryHandler(UserManager<User> userManager,
        ICurrentYearProvider currentYearProvider,
        IAppDbContext dbContext)
    {
        this.userManager = userManager;
        this.currentYearProvider = currentYearProvider;
        this.dbContext = dbContext;
    }

    public async Task<GetTopicsQueryResult> Handle(GetTopicsQuery query, CancellationToken cancellationToken)
    {
        var year = currentYearProvider.GetCurrentYear();
        var user = (await userManager.FindByIdAsync(query.UserId.ToString()))!;

        var data = new GetTopicsData(
            user,
            await userManager.GetRolesAsync(user),
            year,
            query.IncludeOwnedTopics,
            query.Page,
            query.PageSize,
            query.Query ?? string.Empty,
            cancellationToken);

        var topicsCount = await GetTopicsQuery(data).CountAsync(cancellationToken: cancellationToken);
        var pagesCount = (topicsCount + query.PageSize - 1) / query.PageSize;
        var topics = await GetTopicsForRoles(data);

        return new GetTopicsQueryResult(topics.ToList(), pagesCount);
    }

    private async Task<IEnumerable<GetTopicsQueryTopic>> GetTopicsForRoles(GetTopicsData data)
    {
        var topics = await GetTopicsQuery(data)
            .Include(x => x.Owner)
            .Include(x => x.AcademicPrograms)
            .Skip(data.Page * data.Size)
            .Take(data.Size)
            .ToListAsync(data.CancellationToken);

        var result = topics.Select(x =>
            new GetTopicsQueryTopic(x.Id,
                x.Name,
                x.Description,
                new GetTopicsQueryTopicOwner(x.OwnerId, x.Owner!.FullName),
                x.AcademicPrograms.Select(ap => ap.Name).ToList()));

        return result;
    }

    private IQueryable<Topic> GetTopicsQuery(GetTopicsData data)
    {
        var topicsQuery = from topic in dbContext.Topics
            join userRoleTopic in dbContext.UserRoleTopics on topic.Id equals userRoleTopic.TopicId
            join userRole in dbContext.UserRoles on userRoleTopic.UserId equals userRole.UserId
            join role in dbContext.Roles on userRole.RoleId equals role.Id
            where topic.Year == data.Year && userRole.Year == data.Year &&
                  ((data.Roles.Contains(WellKnownRoles.Student) && role.Name != WellKnownRoles.Student) ||
                   (data.Roles.Contains(WellKnownRoles.Supervisor) && role.Name != WellKnownRoles.Supervisor) ||
                   (data.IncludeOwnedTopics && topic.OwnerId == data.User.Id))
            select topic;

        return topicsQuery
            .Distinct()
            .Where(topic => topic.Name.ToUpper().Contains(data.Query.ToUpper()))
            .OrderByDescending(x => x.OwnerId == data.User.Id);
    }
}