using MediatR;

namespace Graduation.Application.Secretaries.GetSecretaries;

public record GetSecretariesQuery(
    string Year,
    string? Query,
    int Page,
    int PageSize) : IRequest<GetSecretariesQueryResult>;