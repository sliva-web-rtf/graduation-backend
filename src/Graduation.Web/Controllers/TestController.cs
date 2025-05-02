using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("test")]
[ApiExplorerSettings(GroupName = "test")]
public class TestController(IAppDbContext appDbContext, UserManager<User> userManager) : ControllerBase
{
    [Authorize(Roles = WellKnownRoles.Admin)]
    [HttpPost("student-passwords")]
    public async Task<IActionResult> StudentPasswords()
    {
        var students = await appDbContext.Students
            .ToListAsync();

        foreach (var student in students)
        {
            var user = await userManager.FindByIdAsync(student.Id.ToString());
            var res = await userManager.ChangePasswordAsync(user, "Aa1234#", "");
            if (!res.Succeeded)
                return BadRequest();
        }

        return Ok();
    }
}