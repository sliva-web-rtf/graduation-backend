namespace Graduation.Application.Topics.GetTopics;

public record GetTopicsQueryResult(IReadOnlyList<GetTopicsQueryTopic> Topics, int PagesCount);

public record GetTopicsQueryTopic(
    Guid Id,
    string Name,
    string? Description,
    GetTopicsQueryTopicOwner Owner,
    IReadOnlyList<string> AcademicPrograms);

public record GetTopicsQueryTopicOwner(Guid Id, string Name);