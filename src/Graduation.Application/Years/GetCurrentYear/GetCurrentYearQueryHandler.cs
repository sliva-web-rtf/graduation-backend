using Graduation.Application.Interfaces.Services;
using MediatR;

namespace Graduation.Application.Years.GetCurrentYear;

public class GetCurrentYearQueryHandler : IRequestHandler<GetCurrentYearQuery, GetCurrentYearQueryResult>
{
    private readonly ICurrentYearProvider currentYearProvider;

    public GetCurrentYearQueryHandler(ICurrentYearProvider currentYearProvider)
    {
        this.currentYearProvider = currentYearProvider;
    }

    public Task<GetCurrentYearQueryResult> Handle(GetCurrentYearQuery request, CancellationToken cancellationToken)
    {
        var year = currentYearProvider.GetCurrentYear();
        return Task.FromResult(new GetCurrentYearQueryResult(year));
    }
}