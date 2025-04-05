using System.ComponentModel.DataAnnotations;
using Graduation.Application.Topics.CreateTopic;
using Graduation.Application.Topics.GetAcademicPrograms;
using Graduation.Application.Topics.GetQualificationWorkRoles;
using Graduation.Application.Topics.GetTopic;
using Graduation.Application.Topics.GetTopics;
using Graduation.Application.Topics.GetUserTopics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("topics")]
[ApiExplorerSettings(GroupName = "topics")]
public class TopicsController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType<GetTopicsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTopics(
        [FromHeader(Name = "X-Year")] string year,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        string? query)
    {
        var request = new GetTopicsQuery(year, page, size, query);
        return Ok(await mediator.Send(request));
    }

    [Authorize]
    [HttpGet("by-user/{userId:Guid}")]
    [ProducesResponseType<GetUserTopicsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserTopics(
        [FromHeader(Name = "X-Year")] string year,
        Guid userId,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        string? query)
    {
        var request = new GetUserTopicsQuery(year, userId, page, size, query);
        return Ok(await mediator.Send(request));
    }

    [Authorize]
    [HttpGet("{id:Guid}")]
    [ProducesResponseType<GetTopicQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTopic(Guid id)
    {
        var request = new GetTopicQuery(id);
        return Ok(await mediator.Send(request));
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType<CreateTopicCommandResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateTopic(CreateTopicCommand request)
    {
        return Ok(await mediator.Send(request));
    }

    [Authorize]
    [HttpGet("academic-programs")]
    [ProducesResponseType<GetAcademicProgramsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAcademicPrograms()
    {
        var request = new GetAcademicProgramsQuery();
        return Ok(await mediator.Send(request));
    }


    [Authorize]
    [HttpGet("qualification-work-roles")]
    [ProducesResponseType<GetQualificationWorkRolesQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetQualificationWorkRoles()
    {
        var request = new GetQualificationWorkRolesQuery();
        return Ok(await mediator.Send(request));
    }
}