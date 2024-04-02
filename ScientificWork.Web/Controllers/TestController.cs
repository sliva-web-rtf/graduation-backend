using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Admins;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;
using ScientificWork.Infrastructure.DataAccess;

namespace ScientificWork.Web.Controllers;

[ApiController]
[Route("test")]
[ApiExplorerSettings(GroupName = "test")]
[Authorize(Roles = nameof(SystemAdmin))]
public class TestController : ControllerBase
{
    private readonly AppDbContext context;
    private readonly UserManager<Professor> professorManager;
    private readonly UserManager<Student> studentManager;

    public TestController(AppDbContext context, UserManager<Professor> professorManager,
        UserManager<Student> studentManager)
    {
        this.context = context;
        this.professorManager = professorManager;
        this.studentManager = studentManager;
    }

    [HttpGet]
    public async Task<ActionResult> Test(IEmailSender emailSender)
    {
        await emailSender.SendEmailAsync("", "test", "test");
        return Ok();
    }
}
