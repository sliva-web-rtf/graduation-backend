using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Commissions;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Commissions.GetCommission;

public class GetCommissionQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<GetCommissionQuery, GetCommissionQueryResult>
{
    public async Task<GetCommissionQueryResult> Handle(GetCommissionQuery request, CancellationToken cancellationToken)
    {
        var commission = await dbContext.Commissions
                             .Include(c => c.Secretary)
                             .Include(c => c.Chairperson)
                             .Include(c => c.CommissionExperts)
                             .ThenInclude(ce => ce.Expert)
                             .Include(c => c.CommissionStudents)
                             .ThenInclude(cs => cs.Student)
                             .ThenInclude(s => s!.User)
                             .Include(c => c.AcademicGroups)
                             .ThenInclude(ag => ag.AcademicProgram)
                             .AsSplitQuery()
                             .Include(c => c.AcademicGroups)
                             .ThenInclude(ag => ag.Students)
                             .ThenInclude(s => s.User)
                             .Include(c => c.AcademicGroups)
                             .ThenInclude(ag => ag.Students)
                             .ThenInclude(s => s.CommissionStudents)
                             .ThenInclude(s => s.Commission)
                             .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
                         ?? throw new NotFoundException("Commission not found");

        var secretary = new GetCommissionQueryResultSecretary(commission.SecretaryId, commission.Secretary!.FullName);
        var chairperson = commission.Chairperson == null
            ? null
            : new GetCommissionQueryResultChairperson(commission.Chairperson.Id, commission.Chairperson.FullName);

        var academicGroups = commission.AcademicGroups
            .Select(ag => new GetCommissionQueryResultAcademicGroup(ag.Id, ag.Name, ag.AcademicProgram?.Name))
            .ToList();

        var stages = await GetStages(commission);

        return new GetCommissionQueryResult($"{commission.Name} ({commission.Secretary.GetInitials()})", secretary,
            chairperson, academicGroups, stages);
    }

    private async Task<IList<GetCommissionQueryResultStage>> GetStages(Commission commission)
    {
        var stages = await dbContext.Stages.Where(s => s.Year == commission.Year).ToListAsync();
        var stagesResult = new List<GetCommissionQueryResultStage>();
        var commissionStudents = commission.AcademicGroups
            .SelectMany(ag => ag.Students)
            .SelectMany(s => s.CommissionStudents)
            .ToList();
        foreach (var stage in stages)
        {
            var students = commission.CommissionStudents
                .Concat(commissionStudents)
                .Where(cs => cs.StageId == stage.Id)
                .Select(s => new GetCommissionQueryResultMovedStudent(
                    s.Student!.Id, s.Student.User!.FullName,
                    s.CommissionId, s.Commission!.Name))
                .Distinct()
                .ToList();

            var experts = commission.CommissionExperts
                .Where(ce => ce.StageId == stage.Id)
                .Select(e => new GetCommissionQueryResultExpert(e.Expert!.Id, e.Expert.FullName, e.IsInvited))
                .ToList();

            stagesResult.Add(new GetCommissionQueryResultStage(stage.Name, experts, students));
        }

        return stagesResult;
    }
}