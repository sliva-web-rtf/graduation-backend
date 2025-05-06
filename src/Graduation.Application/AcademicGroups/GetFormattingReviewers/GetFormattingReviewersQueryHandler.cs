using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.AcademicGroups.GetFormattingReviewers;

public class GetFormattingReviewersQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<GetFormattingReviewersQuery, GetFormattingReviewersQueryResult>
{
    public async Task<GetFormattingReviewersQueryResult> Handle(GetFormattingReviewersQuery request,
        CancellationToken cancellationToken)
    {
        var usersCount = await GetFormattingReviewersQuery(request).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var formattingReviewers = await GetFormattingReviewersQuery(request)
            .OrderBy(s => s.LastName)
            .ThenBy(s => s.FirstName)
            .ThenBy(s => s.Patronymic)
            .Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var reviewersDto = formattingReviewers
            .Select(e => new GetFormattingReviewersQueryResultFormattingReviewer(e.Id, e.FullName))
            .ToList();

        return new GetFormattingReviewersQueryResult(reviewersDto, pagesCount);
    }
    
    private IQueryable<User> GetFormattingReviewersQuery(GetFormattingReviewersQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.Users
            .Where(u => u.UserRoles.Any(ur =>
                ur.Year == request.Year && (ur.Role!.Name == WellKnownRoles.Secretary ||
                                            ur.Role!.Name == WellKnownRoles.HeadSecretary ||
                                            ur.Role!.Name == WellKnownRoles.Expert ||
                                            ur.Role!.Name == WellKnownRoles.Supervisor)))
            .Where(u => queryParts.All(p =>
                EF.Functions.ILike(u.FirstName!, p) ||
                EF.Functions.ILike(u.LastName!, p) ||
                EF.Functions.ILike(u.Patronymic!, p)
            ));
    }
}