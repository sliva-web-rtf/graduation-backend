namespace Graduation.Application.Topics.GetTopic;

public record GetTopicQueryResult(
    string Topic,
    string? Description,
    string? Result,
    string? RequestedRole,
    GetTopicQueryTopicOwner Owner,
    GetTopicQueryTopicStudent? Student,
    GetTopicQueryTopicSupervisor? Supervisor,
    IReadOnlyList<string> AcademicPrograms);

public record GetTopicQueryTopicOwner(Guid Id, string Name);
public record GetTopicQueryTopicStudent(Guid Id, string Name, string Role);
public record GetTopicQueryTopicSupervisor(Guid Id, string Name);