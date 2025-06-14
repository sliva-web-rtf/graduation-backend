using MediatR;

namespace Graduation.Application.Admin.GetApplicationEvents;

public record GetApplicationEventsQuery(string? Query, int Page, int PageSize)
    : IRequest<GetApplicationEventsQueryResult>;