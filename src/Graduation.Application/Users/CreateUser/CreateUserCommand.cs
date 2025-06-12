using MediatR;

namespace Graduation.Application.Users.CreateUser;

public record CreateUserCommand(
    string Password,
    string FirstName,
    string LastName,
    string Patronymic,
    string? Contacts,
    string? About,
    List<string> Roles,
    int? SupervisorLimits,
    Guid? AcademicGroupId,
    string Year)
    : IRequest<CreateUserCommandResult>;