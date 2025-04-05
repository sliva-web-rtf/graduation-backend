using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Application.Topics.GetTopics;
using Graduation.Domain.Topics;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.GetUserTopics;

public class GetUserTopicsQueryHandler : IRequestHandler<GetUserTopicsQuery, GetUserTopicsQueryResult>
{
    private readonly ICurrentYearProvider currentYearProvider;
    private readonly IAppDbContext dbContext;

    public GetUserTopicsQueryHandler(
        ICurrentYearProvider currentYearProvider,
        IAppDbContext dbContext)
    {
        this.currentYearProvider = currentYearProvider;
        this.dbContext = dbContext;
    }

    public async Task<GetUserTopicsQueryResult> Handle(GetUserTopicsQuery query, CancellationToken cancellationToken)
    {
        var year = currentYearProvider.GetCurrentYear();

        var topicsCount = await GetTopicsQuery(query, year).CountAsync(cancellationToken: cancellationToken);
        var pagesCount = (topicsCount + query.PageSize - 1) / query.PageSize;
        
        var topics = await GetTopicsQuery(query, year)
            .Include(x => x.Owner)
            .Include(x => x.AcademicPrograms)
            .Skip(query.Page * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);
        
        var result = topics.Select(x =>
            new GetTopicsQueryTopic(x.Id,
                x.Name,
                x.Description,
                new GetTopicsQueryTopicOwner(x.OwnerId, x.Owner!.FullName),
                x.AcademicPrograms.Select(ap => ap.Name).ToList()));

        return new GetUserTopicsQueryResult(result.ToList(), pagesCount);
    }

    private IQueryable<Topic> GetTopicsQuery(GetUserTopicsQuery query, string year)
    {
        var searchQuery = $"%{query.Query ?? string.Empty}%";

        return dbContext.Topics
            .Where(t => t.UserRoleTopics.Any(urt => urt.UserId == query.UserId) || t.OwnerId == query.UserId)
            .Where(t => t.Year == year)
            .Where(topic => EF.Functions.ILike(topic.Name, searchQuery));
    }
}