using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain;
using Graduation.Domain.Commissions;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Commissions.EditCommissionCommand;

public class EditCommissionCommandHandler(
    IAppDbContext dbContext,
    UserManager<User> userManager,
    IEventsCreator eventsCreator)
    : IRequestHandler<EditCommissionCommand, EditCommissionCommandResult>
{
    public async Task<EditCommissionCommandResult> Handle(EditCommissionCommand request,
        CancellationToken cancellationToken)
    {
        await eventsCreator.Create("User tried to edit commission", request);

        if (await dbContext.Commissions.FirstOrDefaultAsync(c => c.Name == request.Name && request.CommissionId != c.Id,
                cancellationToken) != null)
            throw new DomainException("Commission with given name already exists");

        var chairperson = request.ChairpersonId != null 
            ? await userManager.FindByIdAsync(request.ChairpersonId.ToString()!)
            : null;

        if (chairperson != null && !(await userManager.GetRolesAsync(chairperson)).Any(r => r is WellKnownRoles.Expert))
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

        var commission = await dbContext.Commissions
                             .Include(c => c.AcademicGroups)
                             .Include(c => c.CommissionExperts)
                             .Include(c => c.CommissionStudents)
                             .FirstOrDefaultAsync(c => c.Id == request.CommissionId, cancellationToken)
                         ?? throw new NotFoundException("Commission not found");
        commission.ChairpersonId = chairperson?.Id;
        commission.SecretaryId = secretary.Id;
        commission.Name = request.Name;

        commission.AcademicGroups.Clear();

        var groups = await dbContext.AcademicGroups
            .Where(ag => request.AcademicGroups.Contains(ag.Id))
            .Include(ag => ag.Students)
            .ThenInclude(ag => ag.CommissionStudents)
            .ThenInclude(ag => ag.Commission)
            .ToListAsync(cancellationToken);

        foreach (var group in groups)
        {
            if (group.CommissionId != null && group.CommissionId != commission.Id)
                throw new DomainException($"Group {group.Name} already has commission");
            foreach (var student in group.Students)
            {
                student.CommissionStudents.Clear();
            }
            commission.AcademicGroups.Add(group);
        }

        commission.CommissionStudents.Clear();
        commission.CommissionExperts.Clear();

        foreach (var queryStage in request.Stages)
        {
            var stage = stages.Single(s => s.Name == queryStage.Stage);
            foreach (var student in queryStage.MovedStudents)
            {
                if (await dbContext.CommissionStudents.FirstOrDefaultAsync(cs => cs.StageId == stage.Id &&
                        cs.UserId == student.Id, cancellationToken) is { } commissionStudent)
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
                if (await dbContext.CommissionExperts.FirstOrDefaultAsync(ce => ce.StageId == stage.Id &&
                        ce.UserId == expert.Id, cancellationToken) is { } commissionExpert)
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

        return new EditCommissionCommandResult(request.CommissionId);
    }
}