using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.AcademicGroups;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.AcademicGroups.GetAcademicGroups;

public class GetAcademicGroupsQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<GetAcademicGroupsQuery, GetAcademicGroupsQueryResult>
{
    public async Task<GetAcademicGroupsQueryResult> Handle(GetAcademicGroupsQuery request,
        CancellationToken cancellationToken)
    {
        var count = await GetAcademicGroupsQuery(request).CountAsync(cancellationToken);
        var pagesCount = (count + request.PageSize - 1) / request.PageSize;

        var academicGroups = await GetAcademicGroupsQuery(request)
            .Include(ag => ag.AcademicProgram)
            .OrderBy(ag => ag.Name)
            .Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedAcademicGroups = academicGroups
            .Select(ag => new GetAcademicGroupsQueryResultAcademicGroup(
                ag.Id,
                ag.Name,
                ag.AcademicProgram?.Name,
                ag.CommissionId != null))
            .ToList();

        return new GetAcademicGroupsQueryResult(formattedAcademicGroups, pagesCount);
    }

    private IQueryable<AcademicGroup> GetAcademicGroupsQuery(GetAcademicGroupsQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.AcademicGroups
            .Where(ag => queryParts.All(p => EF.Functions.ILike(ag.Name, p)))
            .Where(ag => ag.Year == request.Year);
    }
}