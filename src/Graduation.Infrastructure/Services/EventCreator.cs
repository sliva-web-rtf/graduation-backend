using Graduation.Application.Interfaces.Authentication;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Events;
using Microsoft.AspNetCore.Http;

namespace Graduation.Infrastructure.Services;

public class EventCreator(
    IHttpContextAccessor httpContextAccessor,
    ILoggedUserAccessor userAccessor,
    IAppDbContext dbContext)
    : IEventsCreator
{
    public async Task Create(string message, object? data = null, string? exception = null)
    {
        var path = httpContextAccessor.HttpContext?.Request.Path;
        var method = httpContextAccessor.HttpContext?.Request.Method;
        dbContext.Events.Add(Event.Create(
            userAccessor.GetCurrentUserId(),
            $"{method} {path}".Trim(),
            message,
            data,
            exception));
        await dbContext.SaveChangesAsync();
    }
}