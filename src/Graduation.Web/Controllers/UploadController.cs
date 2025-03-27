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
}