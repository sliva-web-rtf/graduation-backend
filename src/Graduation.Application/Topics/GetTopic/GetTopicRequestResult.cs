namespace Graduation.Application.Topics.GetTopic;

public record GetTopicRequestResult(
    string Topic,
    string? Description,
    string? Result,
    string? RequestedRole,
    GetTopicRequestTopicOwner Owner,
    GetTopicRequestTopicStudent? Student,
    GetTopicRequestTopicSupervisor? Supervisor,
    IReadOnlyList<string> AcademicPrograms);

public record GetTopicRequestTopicOwner(Guid Id, string Name);
public record GetTopicRequestTopicStudent(Guid Id, string Name, string Role);
public record GetTopicRequestTopicSupervisor(Guid Id, string Name);