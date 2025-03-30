using MediatR;

namespace Graduation.Application.Topics.GetTopics;

public record GetTopicsCommand(Guid UserId) : IRequest<GetTopicsCommandResult>;