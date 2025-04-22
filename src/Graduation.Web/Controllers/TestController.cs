using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.QualificationWorks;
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
    [Authorize]
    [HttpPost("fix-db")]
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

    [Authorize]
    [HttpPost("fill-stages")]
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

    [Authorize]
    [HttpPost("fill-qw")]
    public async Task<IActionResult> FillQW(FillQWData data)
    {
        var students = await appDbContext.Students
            .Where(s => data.StudentsIds.Contains(s.Id))
            .Include(s => s.AcademicGroup)
            .Include(s => s.QualificationWork)
            .ThenInclude(q => q.Stages)
            .ToListAsync();

        var emptyTopic = await appDbContext.Topics
            .Where(t => t.Id == data.EmptyTopicId)
            .SingleAsync();

        foreach (var student in students)
        {
            var qualificationWork = student.QualificationWork;
            if (qualificationWork == null)
            {
                qualificationWork = new QualificationWork(Guid.NewGuid())
                {
                    StudentId = student.Id,
                    TopicId = data.EmptyTopicId,
                    Name = emptyTopic.Name,
                    Year = "2024/2025",
                    Status = QualificationWorkStatus.Approved
                };

                appDbContext.QualificationWorks.Add(qualificationWork);
            }

            foreach (var stageId in data.StagesIds)
            {
                if (qualificationWork.Stages.Any(s => s.StageId == stageId))
                    continue;
                var qwStage = new QualificationWorkStage(Guid.NewGuid())
                {
                    StageId = stageId,
                    QualificationWorkId = qualificationWork.Id,
                    CommissionId = student.AcademicGroup?.CommissionId,
                    TopicId = qualificationWork.TopicId,
                    SupervisorId = qualificationWork.SupervisorId,
                    QualificationWorkRoleId = qualificationWork.QualificationWorkRoleId,
                    TopicName = qualificationWork.Name,
                    CompanyName = qualificationWork.CompanyName,
                    CompanySupervisorName = qualificationWork.CompanySupervisorName
                };
                appDbContext.QualificationWorkStages.Add(qwStage);
            }
        }

        await appDbContext.SaveChangesAsync();

        return Ok();
    }

    public record FillQWData(Guid EmptyTopicId, List<Guid> StudentsIds, List<Guid> StagesIds);
}