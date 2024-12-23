namespace ScientificWork.Infrastructure.Tools.Common.Pagination;

/// <summary>
/// The class contains static methods for <see cref="PagedList{T}" /> and is intended to
/// simplify instantiation and better API.
/// </summary>
public static class PagedListFactory
{
    /// <summary>
    /// Creates paged enumerable from the enumerable source.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    /// <param name="source">Enumerable.</param>
    /// <param name="page">Current page.</param>
    /// <param name="pageSize">Page size.</param>
    /// <returns>Paged list.</returns>
    public static PagedList<T> FromSource<T>(
        IEnumerable<T> source,
        int page,
        int pageSize)
    {
        ArgumentNullException.ThrowIfNull(source);

        var offset = GetOffset(page, pageSize);
        return new PagedList<T>(source.Skip(offset).Take(pageSize).ToList(), page, pageSize,
            source.Count());
    }

    /// <summary>
    /// Creates paged enumerable from the collection source.
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    /// <param name="source">The collection.</param>
    /// <param name="page">The current page.</param>
    /// <param name="pageSize">The page size.</param>
    /// <returns>Paged list.</returns>
    public static PagedList<T> FromSource<T>(
        ICollection<T> source,
        int page,
        int pageSize)
    {
        ArgumentNullException.ThrowIfNull(source);

        var offset = GetOffset(page, pageSize);
        return new PagedList<T>(source.Skip(offset).Take(pageSize).ToList(), page, pageSize,
            source.Count);
    }

    /// <summary>
    /// Creates a paged list from queryable source and query source by page and page size.
    /// The calling will evaluate the query automatically.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    /// <param name="source">Queryable enumerable.</param>
    /// <param name="page">Current page.</param>
    /// <param name="pageSize">Page size.</param>
    /// <returns>Paged list.</returns>
    public static PagedList<T> FromSource<T>(
        IQueryable<T> source,
        int page,
        int pageSize)
    {
        ArgumentNullException.ThrowIfNull(source);

        var offset = GetOffset(page, pageSize);
        return new PagedList<T>(source.Skip(offset).Take(pageSize).ToList(), page, pageSize,
            source.Count());
    }

    /// <summary>
    /// Returns collection of items as a paged list as one page.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    /// <param name="items">Items.</param>
    /// <returns>Paged list.</returns>
    public static PagedList<T> AsOnePage<T>(
        ICollection<T> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        return new PagedList<T>(items, PagedList<object>.FirstPage, items.Count, items.Count);
    }

    /// <summary>
    /// Returns empty paged collection.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    /// <returns>Empty paged list.</returns>
    public static PagedList<T> Empty<T>() => PagedList<T>.Empty;

    /// <summary>
    /// Creates paged enumerable from the collection. Shorthand to simplify type infer.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    /// <param name="items">Items.</param>
    /// <param name="page">The current page.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="totalCount">The total number of items in collection.</param>
    /// <returns>Paged list.</returns>
    public static PagedList<T> Create<T>(ICollection<T> items, int page, int pageSize, int totalCount)
        => new PagedList<T>(items, page, pageSize, totalCount);

    /// <summary>
    /// Calculates the offset for pagination based on the page number and page size.
    /// </summary>
    /// <param name="page">The current page number. Must be greater than or equal to the first page.</param>
    /// <param name="pageSize">The size of each page. Must be greater than zero.</param>
    /// <returns>The offset value, which is the starting index for the specified page.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the <paramref name="page"/> is less than the first page, or when <paramref name="pageSize"/> is less than 1.
    /// </exception>
    internal static int GetOffset(int page, int pageSize)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(page, PagedList<object>.FirstPage);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);

        return (page - 1) * pageSize;
    }
}
