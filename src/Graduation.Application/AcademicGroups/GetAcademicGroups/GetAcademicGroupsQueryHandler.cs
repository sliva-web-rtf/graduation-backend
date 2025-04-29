using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.AcademicGroups;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.AcademicGroups.GetAcademicGroups;

public class GetAcademicGroupsQueryHandler(IAppDbContext dbContext) : IRequestHandler<GetAcademicGroupsQuery, GetAcademicGroupsQueryResult>
{
    public async Task<GetAcademicGroupsQueryResult> Handle(GetAcademicGroupsQuery request, CancellationToken cancellationToken)
    {
        var count = await GetExpertsQuery(request).CountAsync(cancellationToken);
        var pagesCount = (count + request.PageSize - 1) / request.PageSize;

        var academicGroups = await GetExpertsQuery(request).Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedAcademicGroups = academicGroups
            .Select(ag => new GetAcademicGroupsQueryResultAcademicGroup(ag.Id, ag.Name))
            .ToList();

        return new GetAcademicGroupsQueryResult(formattedAcademicGroups, pagesCount);
    }
    
    private IQueryable<AcademicGroup> GetExpertsQuery(GetAcademicGroupsQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.AcademicGroups
            .Where(ag => queryParts.All(p => EF.Functions.ILike(ag.Name, p)));
    }
}