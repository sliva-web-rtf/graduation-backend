namespace Graduation.Application.AcademicGroups.GetAcademicGroups;

public record GetAcademicGroupsQueryResult(
    IList<GetAcademicGroupsQueryResultAcademicGroup> AcademicGroups,
    int PagesCount);

public record GetAcademicGroupsQueryResultAcademicGroup(
    Guid Id,
    string Name,
    string? AcademicProgram,
    Guid? FormattingReviewerId,
    string? FormattingReviewerName,
    bool Blocked,
    Guid? CommissionId,
    string? CommissionName);