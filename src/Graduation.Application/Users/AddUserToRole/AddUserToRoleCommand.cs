using System.ComponentModel.DataAnnotations;
using Graduation.Domain;
using MediatR;

namespace Graduation.Application.Users.AddUserToRole;

public record AddUserToRoleCommand(Guid UserId,
    [AllowedValues(WellKnownRoles.Student, WellKnownRoles.Expert, WellKnownRoles.Supervisor, WellKnownRoles.Secretary)]
    string RoleName) 
    : IRequest;