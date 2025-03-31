using MediatR;

namespace Graduation.Application.Topics.GetQualificationWorkRoles;

public record GetQualificationWorkRolesQuery : IRequest<GetQualificationWorkRolesQueryResult>;