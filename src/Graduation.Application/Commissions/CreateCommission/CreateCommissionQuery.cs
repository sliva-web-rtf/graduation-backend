using MediatR;

namespace Graduation.Application.Commissions.CreateCommission;

public record CreateCommissionQuery(
    string Name,
    Guid SecretaryId,
    Guid ChairpersonId,
    IList<Guid> AcademicGroups,
    IList<CreateCommissionQueryStage> Stages
) : IRequest<CreateCommissionQueryResult>;

public record CreateCommissionQueryStage(
    string Stage,
    IList<CreateCommissionQueryExpert> Experts,
    IList<CreateCommissionQueryMovedStudent> MovedStudents);

public record CreateCommissionQueryExpert(Guid Id, bool IsInvited);

public record CreateCommissionQueryMovedStudent(Guid Id, Guid? CommissionId);