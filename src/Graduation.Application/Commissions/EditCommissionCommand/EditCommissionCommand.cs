using MediatR;

namespace Graduation.Application.Commissions.EditCommissionCommand;

public record EditCommissionCommand(
    Guid CommissionId,
    string Name,
    Guid SecretaryId,
    Guid ChairpersonId,
    IList<Guid> AcademicGroups,
    IList<EditCommissionCommandStage> Stages
) : IRequest<EditCommissionCommandResult>;

public record EditCommissionCommandStage(
    string Stage,
    IList<EditCommissionCommandExpert> Experts,
    IList<EditCommissionCommandMovedStudent> MovedStudents);

public record EditCommissionCommandExpert(Guid Id, bool IsInvited);

public record EditCommissionCommandMovedStudent(Guid Id, Guid? CommissionId);