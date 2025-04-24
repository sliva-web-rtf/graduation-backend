using System.Text.Json.Serialization;

namespace Graduation.Application.Table.GetStudentsTable;

public record GetStudentsTableQueryResult(
    IList<GetStudentsTableQueryStudent> Students,
    string DataType,
    int PagesCount);

public record GetStudentsTableQueryStudent(
    Guid Id,
    string FullName,
    string? AcademicGroup,
    GetStudentsTableQueryQualificationWork? QualificationWork,
    string? Role,
    GetStudentsTableQuerySupervisor? Supervisor,
    string Status,
    GetStudentsTableQueryCommission Commission,
    string? Comment,
    IGetStudentsTableQueryStageData Data);

public record GetStudentsTableQueryQualificationWork(
    Guid Id,
    string? Topic,
    string? Status,
    string? CompanyName,
    string? CompanySupervisorName);

public record GetStudentsTableQuerySupervisor(Guid Id, string FullName);

public record GetStudentsTableQueryCommission(string? Current, string? Prev, string MovementStatus);

[JsonDerivedType(typeof(GetStudentsTableQueryDefenceStageData))]
[JsonDerivedType(typeof(GetStudentsTableQueryPreDefenceStageData))]
[JsonDerivedType(typeof(GetStudentsTableQueryFormattingReviewStageData))]
public interface IGetStudentsTableQueryStageData;

public record GetStudentsTableQueryDefenceStageData(
    decimal? Mark,
    string? Result,
    string? Comment,
    string? Topic,
    bool? IsCommand,
    string? Location,
    DateOnly? Date,
    TimeOnly? Time
) : IGetStudentsTableQueryStageData;

public record GetStudentsTableQueryPreDefenceStageData(
    decimal? Mark,
    string? Result,
    string? Comment,
    string? Topic,
    bool? IsCommand,
    string? Location,
    DateOnly? Date,
    TimeOnly? Time
) : IGetStudentsTableQueryStageData;

public record GetStudentsTableQueryFormattingReviewStageData(
    IList<GetStudentsTableQueryFormattingReviewStageDataDocument> Documents,
    string? Result
) : IGetStudentsTableQueryStageData;

public record GetStudentsTableQueryFormattingReviewStageDataDocument(
    string Name,
    string Status
);