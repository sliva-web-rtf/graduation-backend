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

    [Authorize(Roles = WellKnownRoles.Admin)]
    [HttpPost("fix-commissions-students")]
    public async Task<IActionResult> FixCommissionsStudents()
    {
        var students = await appDbContext.Students
            .Include(s => s.AcademicGroup!.Commission)
            .Include(s => s.CommissionStudents)
            .ToListAsync();

        foreach (var student in students)
        {
            if (student.AcademicGroup?.CommissionId == null)
                continue;
            foreach (var commissionStudent in student.CommissionStudents)
            {
                if (commissionStudent.CommissionId == student.AcademicGroup.CommissionId)
                    appDbContext.CommissionStudents.Remove(commissionStudent);
            }
        }

        await appDbContext.SaveChangesAsync();

        return Ok();
    }
}