using Graduation.Application.Interfaces.Authentication;
using Microsoft.AspNetCore.Http;

namespace Graduation.Infrastructure.Authentication;

internal class LoggedUserAccessor : ILoggedUserAccessor
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public LoggedUserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public Guid GetCurrentUserId()
    {
        if (httpContextAccessor.HttpContext == null)
            throw new InvalidOperationException("There is no active HTTP context specified.");

        return httpContextAccessor.HttpContext.User.GetCurrentUserId();
    }

    public bool IsAuthenticated()
    {
        if (httpContextAccessor.HttpContext == null) return false;

        return httpContextAccessor.HttpContext.User.TryGetCurrentUserId(out _);
    }
}