using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.Infrastructure.Common.Startup.Dependencies;

/// <summary>
/// Logged user accessor implementation.
/// </summary>
internal class LoggedUserAccessor : ILoggedUserAccessor
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public LoggedUserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId { get; set; }

    /// <inheritdoc />
    public Guid GetCurrentUserId()
    {
        if (UserId != null)
        {
            return UserId.Value;
        }

        if (httpContextAccessor.HttpContext == null)
        {
            throw new InvalidOperationException("There is no active HTTP context specified.");
        }

        return httpContextAccessor.HttpContext.User.GetCurrentUserId();
    }

    /// <inheritdoc />
    public bool IsAuthenticated()
    {
        if (httpContextAccessor.HttpContext == null)
        {
            return false;
        }
        return httpContextAccessor.HttpContext.User.TryGetCurrentUserId(out _);
    }
}

internal static class ClaimsPrincipalExtensions
{
    public static bool TryGetCurrentUserId(this ClaimsPrincipal principal, out Guid userId)
    {
        var currentUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!string.IsNullOrEmpty(currentUserId))
        {
            userId = Guid.Parse(currentUserId);
            return true;
        }
        userId = Guid.Empty;
        return false;
    }
    
    public static Guid GetCurrentUserId(this ClaimsPrincipal principal)
    {
        if (TryGetCurrentUserId(principal, out Guid userId))
        {
            return userId;
        }

        throw new InvalidOperationException("Cannot get current logged user identifier.");
    }
}