using System.Linq.Expressions;

namespace Graduation.Application.Extensions;

public static class QueryableExtensions
{
    public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> query,
        Expression<Func<TSource, TKey>> keySelector, string order)
    {
        return order == "asc" ? query.ThenBy(keySelector) : query.ThenByDescending(keySelector);
    }
}