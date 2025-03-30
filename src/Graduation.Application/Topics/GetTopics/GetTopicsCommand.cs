using MediatR;

namespace Graduation.Application.Topics.GetTopics;

public record GetTopicsCommand(Guid UserId, bool IncludeOwnedTopics) : IRequest<GetTopicsCommandResult>;