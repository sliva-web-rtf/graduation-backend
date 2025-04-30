using MediatR;

namespace Graduation.Application.Commissions.CreateCommission;

public record CreateCommissionCommand(
    string Name,
    Guid SecretaryId,
    Guid ChairpersonId,
    IList<Guid> AcademicGroups,
    IList<CreateCommissionCommandStage> Stages
) : IRequest<CreateCommissionCommandResult>;

public record CreateCommissionCommandStage(
    string Stage,
    IList<CreateCommissionCommandExpert> Experts,
    IList<CreateCommissionCommandMovedStudent> MovedStudents);

public record CreateCommissionCommandExpert(Guid Id, bool IsInvited);

public record CreateCommissionCommandMovedStudent(Guid Id, Guid? CommissionId);