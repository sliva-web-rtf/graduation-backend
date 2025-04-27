using Graduation.Domain.QualificationWorks;

namespace Graduation.Application.QualificationWorks.GetQualificationWork;

public record GetQualificationWorkQueryResult(
    GetQualificationWorkQueryResultMainInfo MainInfo,
    GetQualificationWorkQueryResultStageInfo StageInfo,
    GetQualificationWorkQueryFormattingReviewStage FormattingReview);

public record GetQualificationWorkQueryResultMainInfo(
    QualificationWorkStatus Status,
    string TopicName,
    GetQualificationWorkQuerySupervisor? Supervisor,
    GetQualificationWorkQueryStudent? Student,
    string? CompanyName,
    string? CompanySupervisorName,
    string? ExpertComment,
    GetQualificationWorkQueryCommission? Commission
);

public record GetQualificationWorkQuerySupervisor(Guid Id, string Name);

public record GetQualificationWorkQueryStudent(Guid Id, string Name, string? Role);

public record GetQualificationWorkQueryCommission(
    string Name,
    string SecretaryName,
    IList<string> ExpertsNames);

public record GetQualificationWorkQueryResultStageInfo(
    GetQualificationWorkQueryCommission? Commission,
    GetQualificationWorkQuerySupervisor? Supervisor,
    GetQualificationWorkQueryStudent? Student,
    string TopicName,
    string? CompanyName,
    string? CompanySupervisorName,
    string? Location,
    string? Result,
    decimal? Mark,
    bool IsCommand,
    string? Comment,
    DateOnly? Date,
    TimeOnly? Time
);

public record GetQualificationWorkQueryFormattingReviewStage(
    IList<GetQualificationWorkQueryFormattingReviewStageDocument> Documents,
    string? Annotation,
    string? Result
);

public record GetQualificationWorkQueryFormattingReviewStageDocument(
    string Name,
    string Status,
    string? FileName,
    string? Path,
    DateTime? UploadedAt
);