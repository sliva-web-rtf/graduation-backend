using Graduation.Application.Interfaces.Authentication;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.CreateTopic;

public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, CreateTopicCommandResult>
{
    private readonly ICurrentYearProvider currentYearProvider;
    private readonly IAppDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly UserManager<User> userManager;

    public CreateTopicCommandHandler(IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor,
        UserManager<User> userManager, ICurrentYearProvider currentYearProvider)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
        this.userManager = userManager;
        this.currentYearProvider = currentYearProvider;
    }

    public async Task<CreateTopicCommandResult> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var academicPrograms = await dbContext.AcademicPrograms
            .Where(x => request.AcademicPrograms.Contains(x.Name))
            .ToListAsync(cancellationToken);
        if (request.AcademicPrograms.Count != academicPrograms.Count)
        {
            var foundPrograms = academicPrograms.Select(x => x.Name).ToList();
            var notFoundPrograms = request.AcademicPrograms.Except(foundPrograms);
            throw new DomainException($"{string.Join(" ", notFoundPrograms)} programs not found)");
        }

        var requestedRoles = await dbContext.QualificationWorkRoles
            .Where(x => request.RequestedRoles.Contains(x.Role))
            .ToListAsync(cancellationToken);
        if (request.RequestedRoles.Count != requestedRoles.Count)
        {
            var foundRoles = requestedRoles.Select(x => x.Role).ToList();
            var notFoundRoles = request.AcademicPrograms.Except(foundRoles);
            throw new DomainException($"{string.Join(" ", notFoundRoles)} roles not found");
        }

        var user = (await userManager.FindByIdAsync(loggedUserAccessor.GetCurrentUserId().ToString()))!;
        var userRoles = await userManager.GetRolesAsync(user);
        var isSupervisor = userRoles.Any(x => x == WellKnownRoles.Supervisor);

        var role = await dbContext.QualificationWorkRoles.FirstOrDefaultAsync(
            x => x.Role == (isSupervisor ? WellKnownRoles.Supervisor : request.Role),
            cancellationToken);
        if (role == null) throw new DomainException($"Role {request.Role} does not exist");

        var year = currentYearProvider.GetCurrentYear();

        var topic = new Topic(Guid.NewGuid())
        {
            Name = request.Name,
            Description = request.Description,
            Result = request.Result,
            CompanyName = request.CompanyName,
            CompanySupervisorName = request.CompanySupervisorName,
            OwnerId = user.Id,
            Year = year,
            RequiresSupervisor = isSupervisor || request.RequiresSupervisor
        };

        dbContext.Topics.Add(topic);

        var userRoleTopic = new UserRoleTopic
        {
            TopicId = topic.Id,
            UserId = user.Id,
            QualificationWorkRoleId = role.Id
        };
        topic.RequestedRoles.AddRange(requestedRoles);
        topic.AcademicPrograms.AddRange(academicPrograms);
        topic.UserRoleTopics.Add(userRoleTopic);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateTopicCommandResult(topic.Id);
    }
}