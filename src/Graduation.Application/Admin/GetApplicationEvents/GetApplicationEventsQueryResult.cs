namespace Graduation.Application.Admin.GetApplicationEvents;

public record GetApplicationEventsQueryResult(IList<GetApplicationEventsQueryResultEvent> Events, int PagesCount);

public record GetApplicationEventsQueryResultEvent(
    DateTime CreatedAt,
    GetApplicationEventsQueryResultUser User,
    string? Message,
    object? Data,
    string? Exception);

public record GetApplicationEventsQueryResultUser(
    Guid Id,
    string? FirstName,
    string? LastName,
    string? Patronymic);