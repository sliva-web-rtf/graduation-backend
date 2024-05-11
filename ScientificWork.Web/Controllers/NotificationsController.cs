using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.UseCases.Notifications.GetNotifications;
using ScientificWork.UseCases.Notifications.ReadNotification;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Professors controller.
/// </summary>
[ApiController]
[Route("api/notifications")]
[ApiExplorerSettings(GroupName = "notifications")]
[Authorize(Policy = "RegistrationComplete")]
public class NotificationsController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public NotificationsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("get-notifications")]
    public async Task<ActionResult> GetNotification()
    {
        var res = await mediator.Send(new GetNotificationsCommand());
        return Ok(res);
    }

    [HttpGet("read-notifications")]
    public async Task ReadNotification([FromQuery] ReadNotificationCommand query)
    {
        await mediator.Send(query);
    }
}
