using System.ComponentModel.DataAnnotations;
using Graduation.Domain.Documents;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Students;
using MediatR;

namespace Graduation.Application.Table.EditStudentsTable;

public record EditStudentsTableCommand(
    [Required]
    Guid StudentId,
    [Required]
    string Stage,
    string? Topic,
    QualificationWorkStatus QualificationWorkStatus,
    string? CompanyName,
    string? CompanySupervisorName,
    string? Role,
    Guid? SupervisorId,
    string? StudentComment,
    StudentStatus StudentStatus,
    decimal? Mark,
    string? Result,
    string? Comment,
    bool IsCommand,
    DateOnly? Date,
    TimeOnly? Time,
    List<EditStudentsTableCommandDocument>? Documents
) : IRequest<EditStudentsTableCommandResult>;

public record EditStudentsTableCommandDocument(string Name, DocumentStatus DocumentStatus);