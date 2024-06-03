using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;
using ScientificWork.UseCases.ScientificWorks.CreateScientificWork;
using ScientificWork.UseCases.ScientificWorks.DeleteScientificWork;
using ScientificWork.UseCases.ScientificWorks.EnterScientificWork;
using ScientificWork.UseCases.ScientificWorks.GetGeneralInformationById;
using ScientificWork.UseCases.ScientificWorks.GetRecordingSlotById;
using ScientificWork.UseCases.ScientificWorks.GetScientificWorksByUserId;
using ScientificWork.UseCases.ScientificWorks.GetScientificWorksForProfessor;
using ScientificWork.UseCases.ScientificWorks.LeaveScientificWork;
using ScientificWork.UseCases.ScientificWorks.UpdateScientificWork;
using ScientificWork.Web.Infrastructure.Web;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Infrastructure controller.
/// </summary>
[ApiController]
[Route("api/scientificWork")]
[ApiExplorerSettings(GroupName = "scientificWork")]
[Authorize(Policy = "RegistrationComplete")]
public class ScientificWorkController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ScientificWorkController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Create scientific work.
    /// </summary>
    [HttpPost("create-scientific-work")]
    public async Task CreateScientificWork([FromBody] CreateScientificWorkCommand command)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(command);
    }

    /// <summary>
    /// Delete scientific work.
    /// </summary>
    [HttpDelete("delete-scientific-work")]
    public async Task DeleteScientificWork([FromQuery] DeleteScientificWorkCommand command)
    {
        await mediator.Send(command);
    }

    /// <summary>
    /// Update scientific work.
    /// </summary>
    [HttpPut("update-scientific-work")]
    public async Task UpdateScientificWork(UpdateScientificWorkCommand command)
    {
        await mediator.Send(command);
    }

    /// <summary>
    /// Scientific work general info by id.
    /// </summary>
    [HttpGet("general-info-by-id")]
    public async Task<GetGeneralInformationByIdResult> GetGeneralInformationById(
        [FromQuery] GetGeneralInformationByIdQuery query)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        return await mediator.Send(query);
    }

    /// <summary>
    /// Scientific recording slots  by id.
    /// </summary>
    [HttpGet("recording-slots-by-id")]
    public async Task<GetRecordingSlotByIdResult> GetRecordingSlotsById([FromQuery] GetRecordingSlotByIdQuery query)
    {
        return await mediator.Send(query);
    }

    /// <summary>
    /// Scientific work by user id.
    /// </summary>
    [HttpGet("scientific-work-by-user-id")]
    public async Task<List<ScientificWorkDto>> GetScientificWorkByUserId(
        [FromQuery] GetScientificWorksByUserIdQuery query)
    {
        return await mediator.Send(query);
    }

    /// <summary>
    /// List scientific work.
    /// </summary>
    [HttpGet("list-scientific-works")]
    public async Task<ActionResult> GetScientificWorks([FromQuery] GetScientificWorksQuery query)
    {
        var res = await mediator.Send(query);
        return Ok(res);
    }
    
    /// <summary>
    /// Пустышка
    /// </summary>
    /// <param name="command"></param>
    [HttpPost("enter-scientific-work")]
    public async Task EnterScientificWork(EnterScientificWorkCommand command)
    {
    }
    
    /// <summary>
    /// Пустышка
    /// </summary>
    /// <param name="command"></param>
    [HttpDelete("leave-scientific-work")]
    public async Task LeaveScientificWork(LeaveScientificWorkCommand command)
    {
    }
}