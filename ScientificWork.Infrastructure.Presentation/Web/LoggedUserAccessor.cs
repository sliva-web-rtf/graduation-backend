using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.Web.Infrastructure.Web;

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
