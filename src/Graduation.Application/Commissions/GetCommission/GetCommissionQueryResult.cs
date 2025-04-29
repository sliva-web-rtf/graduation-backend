namespace Graduation.Application.Commissions.GetCommission;

public record GetCommissionQueryResult(
    string Name,
    GetCommissionQueryResultSecretary Secretary,
    GetCommissionQueryResultChairperson? Chairperson,
    IList<GetCommissionQueryResultAcademicGroup> AcademicGroups,
    IList<GetCommissionQueryResultStage> Stages
);

public record GetCommissionQueryResultSecretary(Guid Id, string Name);

public record GetCommissionQueryResultChairperson(Guid Id, string Name);

public record GetCommissionQueryResultAcademicGroup(Guid Id, string Name, string? AcademicProgram);

public record GetCommissionQueryResultStage(
    string Stage,
    IList<GetCommissionQueryResultExpert> Experts,
    IList<GetCommissionQueryResultStudent> Students);

public record GetCommissionQueryResultExpert(Guid Id, string Name, bool IsInvited);

public record GetCommissionQueryResultStudent(Guid Id, string Name);