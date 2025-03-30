using Graduation.Application.Topics.GetTopics;
using Graduation.Domain.Users;
using MediatR;

namespace Graduation.Application.Topics.GetSupervisorTopics;

public record GetSupervisorTopicsCommand(User Supervisor, string Year) : IRequest<List<GetTopicsCommandTopic>>;