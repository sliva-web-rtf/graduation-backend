using MediatR;

namespace Graduation.Application.Topics.GetTopic;

public record GetTopicRequest(Guid TopicId) : IRequest<GetTopicRequestResult>;