using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.DataAccess;

namespace ScientificWork.Web.Controllers;

[ApiController]
[Route("test")]
[ApiExplorerSettings(GroupName = "test")]
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
    public async Task<ActionResult> Test()
    {
        var professor = new Professor(Guid.NewGuid());
        var res = await professorManager.CreateAsync(professor);
        var student = new Student(Guid.NewGuid());
        var studRes = await studentManager.CreateAsync(student);
        professor.AddFavoriteStudent(student.Id);
        await context.SaveChangesAsync();
        return Ok(res);
    }
}
