using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Admin.GetApplicationEvents;

public class GetApplicationEventsQueryHandler(IAppDbContext appDbContext)
    : IRequestHandler<GetApplicationEventsQuery, GetApplicationEventsQueryResult>
{
    public async Task<GetApplicationEventsQueryResult> Handle(GetApplicationEventsQuery request,
        CancellationToken cancellationToken)
    {
        var usersCount = await GetEventsQuery(request).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var events = await GetEventsQuery(request)
            .Include(e => e.User)
            .OrderByDescending(e => e.CreatedAt)
            .Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedEvents = events
            .Select(e =>
            {
                var user = new GetApplicationEventsQueryResultUser(
                    e.UserId,
                    e.User!.FirstName,
                    e.User!.LastName,
                    e.User!.Patronymic);

                return new GetApplicationEventsQueryResultEvent(e.CreatedAt, user, e.Message, e.Data, e.Exception);
            })
            .ToList();

        return new GetApplicationEventsQueryResult(formattedEvents, pagesCount);
    }

    private IQueryable<Event> GetEventsQuery(GetApplicationEventsQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return appDbContext.Events
            .Where(e => queryParts.All(p =>
                EF.Functions.ILike(e.Message!, p) ||
                EF.Functions.ILike(e.User!.FirstName!, p) ||
                EF.Functions.ILike(e.User.LastName!, p) ||
                EF.Functions.ILike(e.User.Patronymic!, p)));
    }
}