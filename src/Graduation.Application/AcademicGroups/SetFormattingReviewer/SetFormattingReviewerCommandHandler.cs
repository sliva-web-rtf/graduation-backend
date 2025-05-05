using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.AcademicGroups.SetFormattingReviewer;

public class SetFormattingReviewerCommandHandler(IAppDbContext dbContext, IEventsCreator eventsCreator)
    : IRequestHandler<SetFormattingReviewerCommand, SetFormattingReviewerCommandResult>
{
    public async Task<SetFormattingReviewerCommandResult> Handle(SetFormattingReviewerCommand request,
        CancellationToken cancellationToken)
    {
        await eventsCreator.Create("User tried set formatting reviewer", request);
        
        var academicGroup = await dbContext.AcademicGroups
                                .FirstOrDefaultAsync(ag => ag.Id == request.AcademicGroupId, cancellationToken)
                            ?? throw new NotFoundException("Academic group not found");

        academicGroup.FormattingReviewerId = request.FormattingReviewerId;

        await dbContext.SaveChangesAsync(cancellationToken);

        return new SetFormattingReviewerCommandResult(academicGroup.Id);
    }
}