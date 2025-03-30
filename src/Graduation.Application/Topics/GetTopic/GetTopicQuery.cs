using MediatR;

namespace Graduation.Application.Topics.GetTopic;

public record GetTopicQuery(Guid TopicId) : IRequest<GetTopicQueryResult>;