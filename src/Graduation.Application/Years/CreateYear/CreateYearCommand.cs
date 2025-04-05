using MediatR;

namespace Graduation.Application.Years.CreateYear;

public record CreateYearCommand(string Year) : IRequest;