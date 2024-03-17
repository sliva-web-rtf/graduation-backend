using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.UseCases.Common.Dtos;
using ScientificWork.UseCases.ScientificAreas.GetScientificAreas;
using ScientificWork.UseCases.ScientificInterests.CreateScientificInterests;
using ScientificWork.UseCases.ScientificInterests.GetScientificInterests;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Infrastructure controller.
/// </summary>
[ApiController]
[Route("api/infrastructure")]
[ApiExplorerSettings(GroupName = "infrastructure")]
public class InfrastructureController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public InfrastructureController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// List scientific area.
    /// </summary>
    [HttpGet("list-scientific-area")]
    public async Task<ICollection<ScientificAreasDto>> GetScientificAreas([FromQuery] GetScientificAreasQuery query)
    {
        return await mediator.Send(query);
    }

    /// <summary>
    /// List scientific interests.
    /// </summary>
    [HttpGet("list-scientific-interests")]
    public async Task<IList<string>> GetScientificInterests([FromQuery] GetScientificInterestsQuery query)
    {
        return await mediator.Send(query);
    }

    /// <summary>
    /// Create scientific interests.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("create-scientific-interests-by-exel")]
    public async Task CreateScientificInterests([FromForm] CreateScientificInterestsCommand command)
    {
        await mediator.Send(command);
    }
}
