using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Exceptions;
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
            .ThenInclude(s => s!.Commission)
            .Include(qw => qw.Supervisor)
            .Include(qw => qw.QualificationWorkRole)
            .Include(qw => qw.Stages).ThenInclude(qws => qws.Supervisor)
            .Include(qw => qw.Stages).ThenInclude(qws => qws.QualificationWorkRole)
            .Include(qw => qw.Stages).ThenInclude(qws => qws.Commission)
            .Include(qw => qw.Documents)
            .FirstOrDefaultAsync(qw => qw.Id == request.Id, cancellationToken);

        if (qualificationWork == null)
            throw new NotFoundException("Qualification work with given id not found");


        throw new NotImplementedException();
    }
}