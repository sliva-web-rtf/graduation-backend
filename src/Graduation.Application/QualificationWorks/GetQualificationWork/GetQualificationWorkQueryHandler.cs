using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Exceptions;
using Graduation.Domain.QualificationWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.QualificationWorks.GetQualificationWork;

public class GetQualificationWorkQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<GetQualificationWorkQuery, GetQualificationWorkQueryResult>
{
    public async Task<GetQualificationWorkQueryResult> Handle(GetQualificationWorkQuery request,
        CancellationToken cancellationToken)
    {
        var qualificationWork = await dbContext.QualificationWorks
            .Include(qw => qw.Student)
            .ThenInclude(s => s!.AcademicGroup)
            .ThenInclude(ag => ag!.Commission)
            .ThenInclude(c => c!.Secretary)
            .Include(qw => qw.Student)
            .ThenInclude(s => s!.User)
            .Include(qw => qw.Supervisor)
            .Include(qw => qw.QualificationWorkRole)
            .Include(qw => qw.Stages).ThenInclude(qws => qws.Supervisor)
            .Include(qw => qw.Stages).ThenInclude(qws => qws.QualificationWorkRole)
            .Include(qw => qw.Stages).ThenInclude(qws => qws.Commission)
            .Include(qw => qw.Documents)
            .FirstOrDefaultAsync(qw => qw.Id == request.Id, cancellationToken);

        if (qualificationWork == null)
            throw new NotFoundException("Qualification work with given id not found");

        var mainInfo = await GetMainInfo(qualificationWork);

        return new GetQualificationWorkQueryResult(mainInfo, null, null);
    }


    private async Task<GetQualificationWorkQueryResultMainInfo> GetMainInfo(QualificationWork qualificationWork)
    {
        var student = new GetQualificationWorkQueryStudent(
            qualificationWork.Student!.Id,
            qualificationWork.Student.User!.FullName,
            qualificationWork.QualificationWorkRole?.Role);

        var supervisor = qualificationWork.Supervisor == null
            ? null
            : new GetQualificationWorkQuerySupervisor(
                qualificationWork.Supervisor.Id,
                qualificationWork.Supervisor.FullName);

        GetQualificationWorkQueryCommission? commission = null;
        if (qualificationWork.Student?.AcademicGroup?.Commission is { } commissionDbo)
        {
            var experts = await dbContext.CommissionExperts
                .Where(c => c.CommissionId == commissionDbo.Id)
                .Select(c => c.Expert)
                .Distinct()
                .ToListAsync();
            commission = new GetQualificationWorkQueryCommission(
                qualificationWork.Student.AcademicGroup.Commission.Name,
                qualificationWork.Student.AcademicGroup.Commission.Secretary!.FullName,
                experts.Select(e => e!.FullName).ToList()
            );
        }

        return new GetQualificationWorkQueryResultMainInfo(
            qualificationWork.Status,
            qualificationWork.Name,
            supervisor,
            student,
            qualificationWork.CompanyName,
            qualificationWork.CompanySupervisorName,
            qualificationWork.ExpertComment,
            commission
        );
    }
}