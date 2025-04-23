namespace Graduation.Application.Commissions.GetCommissions;

public record GetCommissionsQueryResult(IList<GetCommissionsQueryResultCommission> Commissions);

public record GetCommissionsQueryResultCommission(string Name, string SecretaryName);