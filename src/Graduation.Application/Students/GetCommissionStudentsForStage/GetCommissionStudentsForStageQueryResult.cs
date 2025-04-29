namespace Graduation.Application.Students.GetCommissionStudentsForStage;

public record GetCommissionStudentsForStageQueryResult(
    IList<GetCommissionStudentsForStageQueryResultStudent> Students,
    int PagesCount);

public record GetCommissionStudentsForStageQueryResultStudent(
    Guid Id,
    string FullName,
    GetCommissionStudentsForStageQueryResultAcademicGroup? AcademicGroup,
    GetCommissionStudentsForStageQueryResultCommission? Commission);

public record GetCommissionStudentsForStageQueryResultAcademicGroup(Guid Id, string Name);

public record GetCommissionStudentsForStageQueryResultCommission(Guid Id, string Name);