using Graduation.Application.Topics.GetTopics;
using Graduation.Domain.Users;
using MediatR;

namespace Graduation.Application.Topics.GetStudentTopics;

public record GetStudentTopicsCommand(User Student, string Year) : IRequest<List<GetTopicsCommandTopic>>;