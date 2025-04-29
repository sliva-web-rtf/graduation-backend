namespace Graduation.Application.Secretaries.GetSecretaries;

public record GetSecretariesQueryResult(IList<GetSecretariesQueryResultSecretary> Secretaries, int PagesCount);

public record GetSecretariesQueryResultSecretary(Guid Id, string Name);