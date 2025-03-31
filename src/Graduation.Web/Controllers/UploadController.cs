using Graduation.Application.UploadManagers;
using Graduation.Application.UploadSecretary;
using Graduation.Application.UploadStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("upload")]
[ApiExplorerSettings(GroupName = "upload")]
public class UploadController : ControllerBase
{
    private readonly IMediator mediator;
    
    public UploadController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpPost("upload-students-by-excel")]
    public async Task<IActionResult> UploadStudents([FromForm] UploadStudentsCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }  
    
    [HttpPost("upload-managers-by-excel")]
    public async Task<IActionResult> UploadManagers([FromForm] UploadManagersCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }   
    
    [HttpPost("upload-secretaries-by-excel")]
    public async Task<IActionResult> UploadSecretaries([FromForm] UploadSecretariesCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}