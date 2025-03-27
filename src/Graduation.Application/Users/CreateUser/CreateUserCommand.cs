using MediatR;

namespace Graduation.Application.Users.CreateUser;

public record CreateUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string Patronymic,
    string? Contacts,
    string? About)
    : IRequest<CreateUserCommandResult>;