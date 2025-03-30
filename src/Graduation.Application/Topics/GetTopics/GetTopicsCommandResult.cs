namespace Graduation.Application.Topics.GetTopics;

public record GetTopicsCommandResult(IReadOnlyList<GetTopicsCommandTopic> Topics);

public record GetTopicsCommandTopic(
    Guid Id,
    string Name,
    string? Description,
    GetTopicsCommandTopicOwner Owner,
    IReadOnlyList<string> AcademicPrograms);

public record GetTopicsCommandTopicOwner(Guid Id, string Name);