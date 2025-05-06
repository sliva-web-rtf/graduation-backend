namespace Graduation.Application.Commissions.GetCommissions;

public record GetCommissionsQueryResult(IList<GetCommissionsQueryResultCommission> Commissions);

public record GetCommissionsQueryResultCommission(Guid Id, string Name, string SecretaryName);