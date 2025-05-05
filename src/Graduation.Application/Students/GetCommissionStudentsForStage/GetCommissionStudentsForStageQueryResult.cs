namespace Graduation.Application.Students.GetCommissionStudentsForStage;

public record GetCommissionStudentsForStageQueryResult(
    IList<GetCommissionStudentsForStageQueryResultStudent> Students,
    int PagesCount);

public record GetCommissionStudentsForStageQueryResultStudent(
    Guid Id,
    string FullName,
    bool Blocked,
    GetCommissionStudentsForStageQueryResultAcademicGroup? AcademicGroup,
    GetCommissionStudentsForStageQueryResultCommission? Commission,
    GetCommissionStudentsForStageQueryResultCommission? PrevCommission);

public record GetCommissionStudentsForStageQueryResultAcademicGroup(Guid Id, string Name);

public record GetCommissionStudentsForStageQueryResultCommission(Guid Id, string Name);