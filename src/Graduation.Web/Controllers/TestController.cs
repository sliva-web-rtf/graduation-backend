using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Users.AddUserToRole;
using Graduation.Application.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("test")]
[ApiExplorerSettings(GroupName = "test")]
public class TestController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IAppDbContext appDbContext;

    public TestController(IMediator mediator, IAppDbContext appDbContext)
    {
        this.mediator = mediator;
        this.appDbContext = appDbContext;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(CreateUserCommand request)
    {
        return Ok(await mediator.Send(request));
    }
    
    [HttpPost("fix-db")]
    public async Task<IActionResult> FixDb()
    {
        var works = await appDbContext.QualificationWorks
            .Include(w => w.Stages)
            .ToListAsync();

        foreach (var qualificationWork in works)
        {
            foreach (var stage in qualificationWork.Stages)
            {
                stage.TopicId = qualificationWork.TopicId;
                stage.SupervisorId = qualificationWork.SupervisorId;
                stage.QualificationWorkRoleId = qualificationWork.QualificationWorkRoleId;
                stage.TopicName = qualificationWork.Name;
                stage.CompanyName = qualificationWork.CompanyName;
                stage.CompanySupervisorName = qualificationWork.CompanySupervisorName;
            }
        }
        
        await appDbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("add-torole")]
    public async Task<IActionResult> AddToRole(AddUserToRoleCommand request)
    {
        await mediator.Send(request);
        return Ok();
    }
}