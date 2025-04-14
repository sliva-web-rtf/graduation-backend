using Graduation.Application.Interfaces.Authentication;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.GetTopics;

public class GetTopicsQueryHandler(
    UserManager<User> userManager,
    IAppDbContext dbContext,
    ILoggedUserAccessor loggedUserAccessor,
    ICurrentYearProvider currentYearProvider)
    : IRequestHandler<GetTopicsQuery, GetTopicsQueryResult>
{
    public async Task<GetTopicsQueryResult> Handle(GetTopicsQuery query, CancellationToken cancellationToken)
    {
        var user = (await userManager.FindByIdAsync(loggedUserAccessor.GetCurrentUserId().ToString()))!;

        var data = new GetTopicsData(
            user,
            await userManager.GetRolesAsync(user),
            query.Year,
            query.Page,
            query.PageSize,
            query.Query ?? string.Empty,
            cancellationToken);

        var topicsCount = await GetTopicsQuery(data).CountAsync(cancellationToken);
        var pagesCount = (topicsCount + query.PageSize - 1) / query.PageSize;
        var topics = await GetTopicsForRoles(data);

        return new GetTopicsQueryResult(topics.ToList(), pagesCount);
    }

    private async Task<IEnumerable<GetTopicsQueryTopic>> GetTopicsForRoles(GetTopicsData request)
    {
        var topics = await GetTopicsQuery(request)
            .Include(x => x.Owner)
            .Include(x => x.AcademicPrograms)
            .Include(x => x.UserRoleTopics)
            .ThenInclude(x => x.QualificationWorkRole)
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .ToListAsync(request.CancellationToken);

        var currentYear = currentYearProvider.GetCurrentYear();

        var result = topics.Select(x =>
        {
            var canJoin = request.Roles.Contains(WellKnownRoles.Supervisor)
                ? x.UserRoleTopics.All(urt => urt.QualificationWorkRole?.Role is not WellKnownRoles.Supervisor)
                : !x.UserRoleTopics.Any(urt => urt.QualificationWorkRole?.Role is not WellKnownRoles.Supervisor);
            canJoin = request.Year == currentYear && canJoin;

            return new GetTopicsQueryTopic(x.Id,
                canJoin,
                x.Name,
                x.Description,
                new GetTopicsQueryTopicOwner(x.OwnerId, x.Owner!.FullName),
                x.AcademicPrograms.Select(ap => ap.Name).ToList());
        });

        return result;
    }

    private IQueryable<Topic> GetTopicsQuery(GetTopicsData request)
    {
        var searchQuery = $"%{request.Query}%";

        return dbContext.Topics
            .Where(t => t.Year == request.Year)
            .Where(topic => EF.Functions.ILike(topic.Name, searchQuery))
            .OrderByDescending(x => x.OwnerId == request.User.Id);
    }

    private record GetTopicsData(
        User User,
        IList<string> Roles,
        string Year,
        int Page,
        int Size,
        string Query,
        CancellationToken CancellationToken);
}