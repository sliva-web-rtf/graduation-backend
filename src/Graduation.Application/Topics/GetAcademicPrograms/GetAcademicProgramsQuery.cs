using MediatR;

namespace Graduation.Application.Topics.GetAcademicPrograms;

public record GetAcademicProgramsQuery : IRequest<GetAcademicProgramsQueryResult>;