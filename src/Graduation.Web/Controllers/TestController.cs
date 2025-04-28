using ClosedXML.Excel;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Stages;
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
    [HttpPost("fix-logins")]
    public async Task<IActionResult> FixLogins()
    {
        var students = await appDbContext.Students
            .Include(s => s.User)
            .Include(s => s.AcademicGroup)
            .ToListAsync();
        
        var counter = 0;
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Имена");
        
            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];
                var expectedUserName = $"{student.User.LastName?.Replace(" ", "")}" +
                                       $"{student.User.FirstName?.Replace(" ", "")}" +
                                       $"{student.User.Patronymic?.Replace(" ", "")}" +
                                       $"{student.AcademicGroup.Name.Replace("-", "")}";
                if (expectedUserName != student.User.UserName)
                {
                    counter++;
                    worksheet.Cell(counter, 1).Value = expectedUserName;
                    worksheet.Cell(counter, 2).Value = student.User.UserName;
                }
            }
        
            workbook.SaveAs("Сломанные логины.xlsx");
        }

        var workbook2 = new XLWorkbook("Сломанные логины.xlsx");
        var worksheet2 = workbook2.Worksheet(1);
        var countRow = worksheet2.Rows().Count();
        for (var i = 1; i <= countRow; i++)
        {
            var login = worksheet2.Cell($"B{i}").GetValue<string>().Trim();
            var newLogin = worksheet2.Cell($"C{i}").GetValue<string>().Trim();
        
            var user = await userManager.FindByNameAsync(login);
            await userManager.SetUserNameAsync(user, newLogin);
        }

        return Ok();
    }

    [Authorize(Roles = WellKnownRoles.Admin)]
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

            var oldQwStage = qualificationWork.Stages.OrderByDescending(s => s.Stage.End).FirstOrDefault();
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

    [Authorize(Roles = WellKnownRoles.Admin)]
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