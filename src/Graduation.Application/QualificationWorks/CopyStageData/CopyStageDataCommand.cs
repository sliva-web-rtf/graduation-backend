using MediatR;

namespace Graduation.Application.QualificationWorks.CopyStageData;

public record CopyStageDataCommand(string Year, string StageFrom, string StageTo)
    : IRequest<CopyStageDataCommandResult>;