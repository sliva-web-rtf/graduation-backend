using MediatR;

namespace Graduation.Application.Stages.GetStages;

public record GetStagesQuery: IRequest<GetStagesQueryResult>;