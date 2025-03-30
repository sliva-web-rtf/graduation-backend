using System.Text.RegularExpressions;
using ClosedXML.Excel;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Exceptions;
using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Graduation.Application.UploadTopics;

public partial class UploadTopicsCommandHandler(IAppDbContext db, UserManager<User> userManager, ICurrentYearProvider yearProvider, ILogger<UploadTopicsCommandHandler> logger) : IRequestHandler<UploadTopicsCommand>
{
    private readonly string currentYear =  yearProvider.GetCurrentYear(); 
    
    public async Task Handle(UploadTopicsCommand request, CancellationToken cancellationToken)
    {
        await using var stream = request.File.OpenReadStream();
        using var workbook = new XLWorkbook(stream);
        
        foreach (var worksheet in workbook.Worksheets.Skip(3).Take(17)) // Пропускаем страницы не группы и берем только их
        {
            var studentsGroup = worksheet.Name;
            // var secretary = secretaryRegex.Match(worksheet.Cell("C1").GetValue<string>()).Groups["FullName"].Value.Trim().Replace(" ", "");
            
            foreach (var row in worksheet.Rows().Skip(3)) // Пропускаем заголовки
            {
                var topic = row.Cell("E").GetValue<string>();
                var fullName = row.Cell("D").GetValue<string>();
                var role = row.Cell("G").GetValue<string>();
                var supervisor = row.Cell("H").GetValue<string>();
                var companySupervisor = row.Cell("K").GetValue<string>();
                var company = row.Cell("L").GetValue<string>();
                var comment = row.Cell("F").GetValue<string>();
                var userName = fullName.Replace(" ", "") + studentsGroup.Replace("-", "");
            
                if (string.IsNullOrWhiteSpace(topic) || string.IsNullOrWhiteSpace(supervisor) || supervisor == "без руководителя от УрФУ" || string.IsNullOrWhiteSpace(role))
                {
                    logger.LogWarning($"Пропущен студент {fullName}");
                    continue;
                    // TODO: Надо добавить секретарей в бд, регулярку для парса написал внизу
                    // supervisor = secretary;
                }
                
                var userEntity = await userManager.FindByNameAsync(userName);
                if (userEntity is null)
                {
                    logger.LogWarning($"Студент {fullName} не найден");
                    continue;
                }
                var supervisorEntity = await userManager.FindByNameAsync(supervisor.Replace(" ", ""));
                if (supervisorEntity is null)
                {
                    logger.LogWarning($"Руководитель {supervisor} не найден");
                    continue;
                }
                
                var topicEntity = new Topic()
                {
                    Name = topic,
                    CompanyName = company, 
                    CompanySupervisorName = companySupervisor, 
                    Year = currentYear,
                    OwnerId = userEntity.Id,
                };
                
                await db.Topics.AddAsync(topicEntity, cancellationToken);
                var roleEntity =
                    await db.QualificationWorkRoles.SingleOrDefaultAsync(r => r.Role == role, cancellationToken);
                
                if (roleEntity is null)
                {
                    roleEntity = new QualificationWorkRole() { Role = role, Year = currentYear };
                    await db.QualificationWorkRoles.AddAsync(roleEntity, cancellationToken);
                }
            
                await db.UserRoleTopics.AddAsync(
                    new UserRoleTopic()
                        { UserId = userEntity.Id, QualificationWorkRoleId = roleEntity.Id, TopicId = topicEntity.Id },
                    cancellationToken);
                var qualificationWork = new QualificationWork()
                {
                    StudentId = userEntity.Id,
                    SupervisorId = supervisorEntity.Id,
                    TopicId = topicEntity.Id,
                    QualificationWorkRoleId = roleEntity.Id,
                    ExpertComment = comment,
                    Topic = topic,
                    CompanyName = company,
                    CompanySupervisorName = companySupervisor, 
                    Year = currentYear
                };
                await db.QualificationWorks.AddAsync(qualificationWork, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
            }
        }

    }

    // private readonly Regex secretaryRegex = SecretaryRegex();
    // [GeneratedRegex(@"/Секретарь:\s*(?:вакансия\s*)?\(?\s*(?<fullName>([А-ЯЁ][а-яё]+)\s+(?:(?:([А-ЯЁ][а-яё]+)\s+([А-ЯЁ][а-яё]+))|(?:([А-ЯЁ]))\.([А-ЯЁ])\.))\)?\s+(?<contacts>.*)")]
    // private static partial Regex SecretaryRegex();
}