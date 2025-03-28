using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;

namespace Graduation.Infrastructure.Services;

public class CurrentYearProvider(IAppDbContext context) : ICurrentYearProvider
{
    public string GetCurrentYear()
    {
        return context.Years.Single(y => y.IsCurrent).YearName;
    }
}