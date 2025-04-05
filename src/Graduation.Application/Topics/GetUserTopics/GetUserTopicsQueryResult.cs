using Graduation.Application.Topics.GetTopics;

namespace Graduation.Application.Topics.GetUserTopics;

public record GetUserTopicsQueryResult(IReadOnlyList<GetTopicsQueryTopic> Topics, int PagesCount);

public record GetUserTopicsQueryTopic(
    Guid Id,
    string Name,
    string? Description,
    GetTopicsQueryTopicOwner Owner,
    IReadOnlyList<string> AcademicPrograms);

public record GetUserTopicsQueryTopicOwner(Guid Id, string Name);