using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.UseCases.Requests.RequestToOrFromProfessor;
using ScientificWork.UseCases.Requests.RequestToStudent;
using ScientificWork.UseCases.Requests.RespondRequest;

namespace ScientificWork.Web.Controllers;

/// <summary>
///
/// </summary>
[ApiController]
[Route("api/request")]
[ApiExplorerSettings(GroupName = "request")]
[Authorize(Policy = "RegistrationComplete")]
public class RequestController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RequestController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// В случаях когда в запросе участвует профессор.
    /// </summary>
    [HttpPost("to-or-from-professor")]
    public async Task RequestToOrFromProfessor([FromBody] RequestToOrFromProfessorCommand command)
    {
        await mediator.Send(command);
    }

    /// <summary>
    /// В случаях когда в запросе делает студент студенту.
    /// </summary>
    [HttpPost("to-student")]
    public async Task RequestToStudent([FromBody] RequestToStudentCommand command)
    {
        await mediator.Send(command);
    }

    /// <summary>
    /// Ответ (Agree or Disagree).
    /// </summary>
    [HttpPost("respond")]
    public async Task RespondRequest([FromBody] RespondRequestCommand command)
    {
        await mediator.Send(command);
    }
}
