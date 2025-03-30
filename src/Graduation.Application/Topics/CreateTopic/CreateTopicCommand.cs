using MediatR;

namespace Graduation.Application.Topics.CreateTopic;

public record CreateTopicCommand : IRequest<CreateTopicCommandResult>;