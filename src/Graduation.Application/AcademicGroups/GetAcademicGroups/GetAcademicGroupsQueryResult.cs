namespace Graduation.Application.AcademicGroups.GetAcademicGroups;

public record GetAcademicGroupsQueryResult(
    IList<GetAcademicGroupsQueryResultAcademicGroup> AcademicGroups,
    int PagesCount);

public record GetAcademicGroupsQueryResultAcademicGroup(
    Guid Id,
    string Name,
    string? AcademicProgram,
    bool Blocked);