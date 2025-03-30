namespace Graduation.Application.Topics.GetTopics;

public record GetTopicsCommandResult(List<GetTopicsCommandTopic> Topics);

public record GetTopicsCommandTopic(Guid Id, string Name, string? Description, string? Result);