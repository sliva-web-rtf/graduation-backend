using MediatR;

namespace Graduation.Application.AcademicGroups.GetFormattingReviewers;

public record GetFormattingReviewersQuery(
    string Year,
    string? Query,
    int Page,
    int PageSize) : IRequest<GetFormattingReviewersQueryResult>;