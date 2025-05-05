using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.AcademicGroups.SetFormattingReviewer;

public class SetFormattingReviewerCommandHandler(IAppDbContext dbContext)
    : IRequestHandler<SetFormattingReviewerCommand, SetFormattingReviewerCommandResult>
{
    public async Task<SetFormattingReviewerCommandResult> Handle(SetFormattingReviewerCommand request,
        CancellationToken cancellationToken)
    {
        var academicGroup = await dbContext.AcademicGroups
                                .FirstOrDefaultAsync(ag => ag.Id == request.AcademicGroupId, cancellationToken)
                            ?? throw new NotFoundException("Academic group not found");

        academicGroup.FormattingReviewerId = request.FormattingReviewerId;

        await dbContext.SaveChangesAsync(cancellationToken);

        return new SetFormattingReviewerCommandResult(academicGroup.Id);
    }
}