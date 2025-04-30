namespace Graduation.Application.Commissions.GetCommissionsForEditing;

public record GetCommissionsForEditingQueryResult(IList<GetCommissionsForEditingQueryResultCommission> Commissions);

public record GetCommissionsForEditingQueryResultCommission(
    Guid Id,
    string Name,
    string SecretaryName,
    string? ChairpersonName,
    IList<string> AcademicGroups);