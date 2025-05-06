namespace Graduation.Application.AcademicGroups.GetFormattingReviewers;

public record GetFormattingReviewersQueryResult(
    IList<GetFormattingReviewersQueryResultFormattingReviewer> FormattingReviewers,
    int PagesCount);

public record GetFormattingReviewersQueryResultFormattingReviewer(Guid Id, string Name);