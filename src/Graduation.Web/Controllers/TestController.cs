using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Stages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("test")]
[ApiExplorerSettings(GroupName = "test")]
public class TestController(IAppDbContext appDbContext) : ControllerBase
{
    [HttpPost("fix-db")]
    [Authorize]
    public async Task<IActionResult> FixDb()
    {
        var works = await appDbContext.QualificationWorks
            .Include(w => w.Stages)
            .ToListAsync();

        foreach (var qualificationWork in works)
        foreach (var stage in qualificationWork.Stages)
        {
            stage.TopicId = qualificationWork.TopicId;
            stage.SupervisorId = qualificationWork.SupervisorId;
            stage.QualificationWorkRoleId = qualificationWork.QualificationWorkRoleId;
            stage.TopicName = qualificationWork.Name;
            stage.CompanyName = qualificationWork.CompanyName;
            stage.CompanySupervisorName = qualificationWork.CompanySupervisorName;
        }

        await appDbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("fill-stages")]
    [Authorize]
    public async Task<IActionResult> FillStages()
    {
        var works = await appDbContext.QualificationWorks
            .Include(w => w.Stages)
            .ToListAsync();

        var stages = await appDbContext.Stages.ToListAsync();

        foreach (var qualificationWork in works)
        foreach (var stage in stages)
        {
            if (qualificationWork.Stages.Any(s => s.StageId == stage.Id))
                continue;

            var oldQwStage = qualificationWork.Stages.FirstOrDefault();
            if (oldQwStage == null)
                continue;

            var qwStage = new QualificationWorkStage(Guid.NewGuid())
            {
                StageId = stage.Id,
                QualificationWorkId = qualificationWork.Id,
                CommissionId = oldQwStage.CommissionId,
                TopicId = qualificationWork.TopicId,
                SupervisorId = qualificationWork.SupervisorId,
                QualificationWorkRoleId = qualificationWork.QualificationWorkRoleId,
                TopicName = qualificationWork.Name,
                CompanyName = qualificationWork.CompanyName,
                CompanySupervisorName = qualificationWork.CompanySupervisorName,
                IsCommand = oldQwStage.IsCommand
            };
            appDbContext.QualificationWorkStages.Add(qwStage);
        }

        await appDbContext.SaveChangesAsync();
        return Ok();
    }
}