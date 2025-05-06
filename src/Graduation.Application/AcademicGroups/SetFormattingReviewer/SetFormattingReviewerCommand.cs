using MediatR;

namespace Graduation.Application.AcademicGroups.SetFormattingReviewer;

public record SetFormattingReviewerCommand(Guid AcademicGroupId, Guid FormattingReviewerId)
    : IRequest<SetFormattingReviewerCommandResult>;