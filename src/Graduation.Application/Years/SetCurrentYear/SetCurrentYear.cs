using MediatR;

namespace Graduation.Application.Years.SetCurrentYear;

public record SetCurrentYear(string Year) : IRequest;