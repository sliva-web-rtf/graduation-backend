using System.Collections;

namespace ScientificWork.Infrastructure.Tools.Common.Pagination;

[Serializable]
public class PagedList<T> : IEnumerable<T>
{
    /// <summary>
    /// Source collection.
    /// </summary>
    protected internal ICollection<T> Items { get; set; } = new List<T>();

    /// <summary>
    /// The total number of items in collection.
    /// </summary>
    public int TotalCount { get; protected internal set; }

    /// <summary>
    /// Gets the element at the specified index. It only works for list collections.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get.</param>
    public T this[int index] => ((IList<T>)Items)[index];

    /// <summary>
    /// The number of items to skip.
    /// </summary>
    public int Offset { get; protected internal set; }

    /// <summary>
    /// The maximum number of items to take.
    /// </summary>
    public int Limit { get; protected internal set; }

    /// <summary>
    /// First-page index.
    /// </summary>
    public const int FirstPage = 1;

    /// <summary>
    /// Current page. It starts at 1.
    /// </summary>
    public int Page { get; protected internal set; }

    /// <summary>
    /// Page size. Max number of items on page.
    /// </summary>
    public int PageSize { get; protected internal set; }

    /// <summary>
    /// Empty offset limit list.
    /// </summary>
    public static PagedList<T> Empty { get; } =
        new PagedList<T>(new List<T>(), page: 1, pageSize: 1, totalCount: 0);
    
    /// <summary>
    /// Total pages.
    /// </summary>
    public int TotalPages
    {
        get
        {
            if (PageSize >= int.MaxValue - TotalCount)
            {
                return FirstPage;
            }
            return (TotalCount + PageSize - 1) / PageSize;
        }
    }
    
    /// <summary>
    /// Is pagination now on the first page.
    /// </summary>
    public bool IsFirstPage => Page == FirstPage;

    /// <summary>
    /// Is pagination now on the last page.
    /// </summary>
    public bool IsLastPage => Page == TotalPages;

    /// <summary>
    /// Parameterless constructor.
    /// </summary>
    protected PagedList()
    {
    }
    
    public PagedList(
        ICollection<T> items,
        int page,
        int pageSize,
        int totalCount)
    {
        var offset = (page - 1) * pageSize;
        ArgumentOutOfRangeException.ThrowIfNegative(totalCount);
        ArgumentOutOfRangeException.ThrowIfNegative(offset);
        ArgumentOutOfRangeException.ThrowIfLessThan(page, FirstPage);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);


        this.Items = items ?? throw new ArgumentNullException(nameof(items));
        this.TotalCount = totalCount;
        this.Offset = offset;
        this.Limit = pageSize;
        this.Page = page;
        this.PageSize = pageSize;
    }
    
    /// <summary>
    /// Convert items into another type.
    /// </summary>
    /// <param name="converter">Converter function.</param>
    /// <typeparam name="TNew">New type.</typeparam>
    /// <returns>New list.</returns>
    public new PagedList<TNew> Convert<TNew>(Func<T, TNew> converter)
        => new PagedList<TNew>
        {
            Items = Items.Select(converter).ToList(),
            Page = Page,
            PageSize = PageSize,
            Limit = Limit,
            Offset = Offset,
            TotalCount = TotalCount
        };
    
    public IEnumerator<T> GetEnumerator()
    {
        return Items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
