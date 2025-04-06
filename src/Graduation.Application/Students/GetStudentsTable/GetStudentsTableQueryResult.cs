using System.Text.Json.Serialization;

namespace Graduation.Application.Students.GetStudentsTable;

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
    IGetStudentsTableQueryStageData Data);

public record GetStudentsTableQueryQualificationWork(
    Guid Id,
    string Topic,
    string? Status,
    string? CompanyName,
    string? CompanySupervisorName);

public record GetStudentsTableQuerySupervisor(Guid Id, string FullName);

[JsonDerivedType(typeof(GetStudentsTableQueryDefenceStageData))]
[JsonDerivedType(typeof(GetStudentsTableQueryPreDefenceStageData))]
[JsonDerivedType(typeof(GetStudentsTableQueryFormattingReviewStageData))]
public interface IGetStudentsTableQueryStageData;

public record GetStudentsTableQueryDefenceStageData(
    decimal? Mark,
    string? Result,
    string? Comment,
    string? Topic,
    bool? IsCommand
) : IGetStudentsTableQueryStageData;

public record GetStudentsTableQueryPreDefenceStageData(
    decimal? Mark,
    string? Result,
    string? Comment,
    string? Topic,
    bool? IsCommand
) : IGetStudentsTableQueryStageData;

public record GetStudentsTableQueryFormattingReviewStageData(
    IList<GetStudentsTableQueryFormattingReviewStageDataDocument> Documents
) : IGetStudentsTableQueryStageData;

public record GetStudentsTableQueryFormattingReviewStageDataDocument(
    string Name,
    string Status
);