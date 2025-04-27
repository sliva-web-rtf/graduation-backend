using Graduation.Domain.Stages;

namespace Graduation.Application.Stages.GetStages;

public record GetStagesQueryResult(IList<GetStagesQueryResultStage> Stages);

public record GetStagesQueryResultStage(
    string Name,
    StageType Type,
    DateOnly BeginsAt,
    DateOnly EndsAt,
    bool IsCurrent);