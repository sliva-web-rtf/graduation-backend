using MediatR;

namespace Graduation.Application.Table.SetStudentsStageDate;

public record SetStudentsStageDateCommand(IList<Guid> StudentIds, string Stage, DateOnly Date, string Location)
    : IRequest;