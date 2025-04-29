namespace Graduation.Application.Experts.GetExperts;

public record GetExpertsQueryResult(IList<GetExpertsQueryResultExpert> Experts, int PagesCount);

public record GetExpertsQueryResultExpert(Guid Id, string Name);