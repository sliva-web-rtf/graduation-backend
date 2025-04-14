namespace Graduation.Application.Topics.GetUserTopics;

public record GetUserTopicsQueryResult(IReadOnlyList<GetUserTopicsQueryTopic> Topics, int PagesCount);

public record GetUserTopicsQueryTopic(
    Guid Id,
    string Name,
    string? Description,
    GetUserTopicsQueryTopicOwner Owner,
    IReadOnlyList<string> AcademicPrograms);

public record GetUserTopicsQueryTopicOwner(Guid Id, string Name);