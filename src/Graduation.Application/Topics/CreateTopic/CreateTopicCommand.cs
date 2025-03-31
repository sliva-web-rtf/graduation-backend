using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Graduation.Application.Topics.CreateTopic;

public record CreateTopicCommand(
    string Name,
    string? Description,
    string? Result,
    string? Role,
    [MinLength(1)]
    IList<string> AcademicPrograms,
    IList<string> RequestedRoles,
    string? CompanyName,
    string? CompanySupervisorName,
    bool RequiresSupervisor
) : IRequest<CreateTopicCommandResult>;