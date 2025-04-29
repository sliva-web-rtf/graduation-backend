using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain;
using Graduation.Domain.Commissions;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Commissions.CreateCommission;

public class CreateCommissionQueryHandler(
    IAppDbContext dbContext,
    UserManager<User> userManager,
    ICurrentYearProvider currentYearProvider)
    : IRequestHandler<CreateCommissionQuery, CreateCommissionQueryResult>
{
    public async Task<CreateCommissionQueryResult> Handle(CreateCommissionQuery request,
        CancellationToken cancellationToken)
    {
        if (await dbContext.Commissions.FirstOrDefaultAsync(c => c.Name == request.Name, cancellationToken) != null)
            throw new DomainException("Commission with given name already exists");

        var chairperson = await userManager.FindByIdAsync(request.ChairpersonId.ToString())
                          ?? throw new DomainException("Chairperson with given id does not exist");

        if (!(await userManager.GetRolesAsync(chairperson)).Any(r => r is WellKnownRoles.Expert))
            throw new DomainException("Chairperson must be in role expert");

        var secretary = await userManager.FindByIdAsync(request.SecretaryId.ToString())
                        ?? throw new DomainException("Secretary with given id does not exist");

        if (!(await userManager.GetRolesAsync(secretary)).Any(r =>
                r is WellKnownRoles.Secretary or WellKnownRoles.HeadSecretary))
            throw new DomainException("Secretary must be in role secretary");

        var stagesNames = request.Stages.Select(st => st.Stage).ToList();
        var stages = await dbContext.Stages.Where(s => stagesNames.Contains(s.Name)).ToListAsync(cancellationToken);
        if (stagesNames.Count != stages.Count)
            throw new DomainException("Some of stages not found");

        var commission = new Commission(Guid.NewGuid())
        {
            ChairpersonId = chairperson.Id,
            SecretaryId = secretary.Id,
            Name = request.Name,
            Year = currentYearProvider.GetCurrentYear()
        };
        dbContext.Commissions.Add(commission);

        var groups = await dbContext.AcademicGroups
            .Where(ag => request.AcademicGroups.Contains(ag.Id))
            .ToListAsync(cancellationToken);

        foreach (var group in groups)
        {
            if (group.CommissionId != null)
                throw new DomainException($"Group {group.Name} already has commission");
            group.CommissionId = commission.Id;
        }

        foreach (var queryStage in request.Stages)
        {
            var stage = stages.Single(s => s.Name == queryStage.Stage);
            foreach (var student in queryStage.MovedStudents)
            {
                if (await dbContext.CommissionStudents.FirstOrDefaultAsync(cancellationToken) is { } commissionStudent)
                    dbContext.CommissionStudents.Remove(commissionStudent);

                dbContext.CommissionStudents.Add(new CommissionStudent
                {
                    CommissionId = student.CommissionId ?? commission.Id,
                    StageId = stage.Id,
                    UserId = student.Id
                });
            }

            foreach (var expert in queryStage.Experts)
            {
                if (await dbContext.CommissionExperts.FirstOrDefaultAsync(cancellationToken) is { } commissionExpert)
                    dbContext.CommissionExperts.Remove(commissionExpert);

                dbContext.CommissionExperts.Add(new CommissionExpert
                {
                    StageId = stage.Id,
                    UserId = expert.Id,
                    CommissionId = commission.Id,
                    IsInvited = expert.IsInvited
                });
            }
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateCommissionQueryResult(commission.Id);
    }
}